using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Infrastructure;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Interfaces
{
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
    }
}
