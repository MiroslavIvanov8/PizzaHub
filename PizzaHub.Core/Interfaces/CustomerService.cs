namespace PizzaHub.Core.Interfaces
{
    using HouseRentingSystem.Infrastructure.Data.Common;
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
        public async Task<int> GetCustomerId(string userId)
        {
            if (await CustomerExists(userId))
            {
                Customer? customer = await this.repository.AllReadOnly<Customer>().FirstOrDefaultAsync(c => c.UserId == userId);
                return customer.Id;
            }

            return 0;
        }

        public async Task<bool> CustomerExists(string userId)
        {
            return await this.repository.AllReadOnly<Customer>().AnyAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<OrderViewModel>> ShowOrders(int userId)
        {
            var userOrders = await this.repository
                .All<Order>()
                .Where(o => o.CustomerId == userId)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    RestaurantId = o.RestaurantId,
                    Status = o.Status.Name,
                    OrderItems = o.Items.Select(oi => oi.Name)
                })
                .ToListAsync();

            return userOrders;

        }
    }
}
