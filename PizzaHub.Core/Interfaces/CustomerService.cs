using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
{
    public class CustomerService : ICustomerService
    {
        private readonly PizzaHubDbContext dbContext;

        public CustomerService(PizzaHubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> GetCustomerId(string userId)
        {
            if (await CustomerExists(userId))
            {
                Customer? customer = await this.dbContext.Customers.FirstOrDefaultAsync(c => c.UserId == userId);
                return customer.Id;
            }

            return 0;
        }

        public async Task<bool> CustomerExists(string userId)
        {
            return await this.dbContext.Customers.AnyAsync(c => c.UserId == userId);
        }
    }
}
