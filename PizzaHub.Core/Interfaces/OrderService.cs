
using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
{
    public class OrderService : IOrderService
    {
        private readonly PizzaHubDbContext dbContext;

        public OrderService(PizzaHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateOrderFromCartAsync(int customerId, string address, string paymentMethod)
        {
            
            // Get customer cart items
            var cartItems = await dbContext.CustomerCart
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

                await dbContext.Orders.AddAsync(order);
                await dbContext.SaveChangesAsync();

                // Add order items from cart
                foreach (var cartItem in cartItems)
                {
                    var menuItem = await dbContext.MenuItems.FindAsync(cartItem.MenuItemId);

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
                    }
                    else
                    {
                        return false;
                    }
                }

                // Remove items from the customer cart
                var cartItemsToRemove = dbContext.CustomerCart
                    .Where(cart => cart.CustomerId == customerId)
                    .ToList();

                dbContext.CustomerCart.RemoveRange(cartItemsToRemove);

                await dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
  