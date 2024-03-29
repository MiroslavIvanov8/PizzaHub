using Microsoft.EntityFrameworkCore;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Common;
using PizzaHub.Infrastructure.Constants;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Core.Services
{
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
            var orders = await this.repository.All<Order>()
                .Where(o => o.CustomerId == userId).ToListAsync();

            //TODO change the models so it shows the correct quantity of every item in the order
            var orderViewModels = orders.Select(order => new OrderViewModel
            {
                Id = order.Id,
                Restaurant = order.Restaurant.Name,
                Status = order.OrderStatus.Name,
                Amount = order.TotalAmount,
                CreatedOn = order.CreatedOn.ToString(DataConstants.AppGlobalConstants.DateFormat),
                OrderItems = order.Items.Select(oi => oi.MenuItem.Name),
                
            }).OrderByDescending(o => o.CreatedOn);

            return orderViewModels;
        }
    }
}

