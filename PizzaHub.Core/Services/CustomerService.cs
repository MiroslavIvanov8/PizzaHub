using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Constants;
using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.Core.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using PizzaHub.Core.Contracts;
    using PizzaHub.Core.ViewModels.Order;
    using PizzaHub.Infrastructure.Data.Models;

    public class CustomerService : ICustomerService
    {
        private readonly IRepository repository;

        public CustomerService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> GetCustomerIdAsync(string userId)
        {
            if (await CustomerExistsAsync(userId))
            {
                Customer? customer = await this.repository.AllReadOnly<Customer>()
                    .FirstOrDefaultAsync(c => c.UserId == userId);
                return customer.Id;
            }

            return 0;
        }

        public async Task<bool> CustomerExistsAsync(string userId)
        {
            return await this.repository.AllReadOnly<Customer>().AnyAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<OrderViewModel>> ShowOrdersAsync(int userId)
        {
            // Retrieve all orders for the given userId
            var orders = await this.repository.All<Order>()
                .Where(o => o.CustomerId == userId).ToListAsync();


            // Map Order entities to OrderViewModels
            var orderViewModels = orders.Select(order => new OrderViewModel
            {
                Id = order.Id,
                Restaurant = order.Restaurant.Name,
                Status = order.OrderStatusId.ToString(),
                Amount = order.TotalAmount,
                CreatedOn = order.CreatedOn.ToString(DataConstants.DateFormat),
                OrderItems = order.Items.Select(oi => oi.MenuItem.Name)
            }).OrderByDescending(o => o.CreatedOn);

            return orderViewModels;
        }
    }
}

