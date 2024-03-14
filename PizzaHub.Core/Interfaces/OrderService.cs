
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
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
                    StatusId = 1,
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
    }
}
  