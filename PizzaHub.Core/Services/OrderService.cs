using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Constants;
using PizzaHub.Infrastructure.Data.Models;
using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;

        public OrderService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateOrderFromCartAsync(int customerId, string address, string paymentMethod)
        {
            
            // Get customer cart items
            var cartItems = await this.repository.All<CustomerCart>()
                .Where(cart => cart.CustomerId == customerId)
                .Select(cart => new
                {
                    cart.MenuItemId,
                    cart.Quantity
                })
                .ToListAsync();

            if (cartItems.Any())
            {
                // Create a new order

                var order = new Order
                {
                    CustomerId = customerId,
                    RestaurantId = 1,
                    PaymentMethodId = paymentMethod == "cash" ? 1 : 2,
                    Address = address,
                    OrderStatusId = (int)OrderStatusEnum.Pending,
                    CreatedOn = DateTime.UtcNow,
                    TotalAmount = 0, // Will fill out in next step
                };

                await this.repository.AddAsync(order);
                await this.repository.SaveChangesAsync();

                // Add order items from cart
                foreach (var cartItem in cartItems)
                {
                    var menuItem = await this.repository.AllReadOnly<MenuItem>().FirstOrDefaultAsync(mi => mi.Id == cartItem.MenuItemId);

                    if (menuItem != null)
                    {
                        var orderItem = new OrderItem
                        {
                            OrderId = order.Id,
                            MenuItemId = cartItem.MenuItemId,
                            Quantity = cartItem.Quantity,
                            Price = menuItem.Price
                        };

                        order.TotalAmount += orderItem.Price * orderItem.Quantity;
                        await this.repository.AddAsync(orderItem);
                    }
                    else
                    {
                        return false;
                    }
                }

                // Remove items from the customer cart
                var cartItemsToRemove = await this.repository.All<CustomerCart>()
                    .Where(cart => cart.CustomerId == customerId)
                    .ToListAsync();

                await this.repository.RemoveRange(cartItemsToRemove);

                await this.repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<string>> GetOrderItemNamesAsync(int orderId)
        {
            var orderItems = await repository.All<OrderItem>()
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();

            // Extract MenuItem names from OrderItems
            var menuItemNames = orderItems.Select(oi => oi.MenuItem.Name);

            return menuItemNames;
        }

        public async Task<IEnumerable<OrderMenuItemWithQuantityViewModel>> GetOrderMenuItemWithQuantityViewmodelAsync(int orderId)
        {
            var orderItems = await repository.All<OrderItem>()
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();

            var orderItemsWithQuantity = orderItems.Select(o => new OrderMenuItemWithQuantityViewModel()
            {
                Id = o.OrderId,
                Name = o.MenuItem.Name,
                Quantity = o.Quantity,
            });

            return orderItemsWithQuantity;
        }

        public async Task<IEnumerable<string>> GetStatusNamesAsync()
        {
            return await this.repository
                .AllReadOnly<OrderStatus>()
                .Select(s => s.Name)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderAsync(int id)
        {
           return await this.repository.All<Order>().FirstOrDefaultAsync(o => o.Id == id);
        }
        
        public async Task<IEnumerable<DetailedOrderViewModel>> GetAllReadOnlyDetailedOrdersViewModelAsync()
        {
            return await this.repository.AllReadOnly<Order>().Select(o => new DetailedOrderViewModel()
            {
                Id = o.Id,
                Restaurant = o.Restaurant.Name,
                Address = o.Address,
                Amount = o.TotalAmount,
                CreatedOn = o.CreatedOn.ToString(DataConstants.DateFormat),
                Customer = $"{o.Customer.User.FirstName} {o.Customer.User.LastName}",
                OrderItems = o.Items.Select(oi => new OrderMenuItemWithQuantityViewModel()
                {
                    Id = oi.Id,
                    Name = oi.MenuItem.Name,
                    Quantity = oi.Quantity,
                }).ToList(),
                Status = o.OrderStatus.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<DetailedOrderViewModel>> GetAllDetailedOrdersViewModelAsync()
        {
            return await this.repository.All<Order>().Select(o => new DetailedOrderViewModel()
            {
                Id = o.Id,
                Restaurant = o.Restaurant.Name,
                Address = o.Address,
                Amount = o.TotalAmount,
                CreatedOn = o.CreatedOn.ToString(DataConstants.DateFormat),
                Customer = $"{o.Customer.User.FirstName} {o.Customer.User.LastName}",
                OrderItems = o.Items.Select(oi => new OrderMenuItemWithQuantityViewModel()
                {
                    Id = oi.Id,
                    Name = oi.MenuItem.Name,
                    Quantity = oi.Quantity,
                }).ToList(),
                Status = o.OrderStatus.Name
            }).ToListAsync();
        }
    }
}
  