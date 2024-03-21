using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.Core.Interfaces
{
    using Contracts;
    using Infrastructure.Data.Models;
    using PizzaHub.Core.ViewModels.Order;
    using PizzaHub.Infrastructure.Constants;

    public class AdminService : IAdminService
    {
        private IRepository repository;

        public AdminService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task MarkOrderAcceptedAsync(int orderId)
        {
            Order? order = await this.repository.All<Order>().FirstOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                order.OrderStatusId = (int)OrderStatusEnum.InProgress;
            }

            await this.repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ShowOrderViewModel>> ShowTodayOrdersAsync()
        {
            var models = await this.repository.AllReadOnly<Order>()
                .OrderByDescending(o => o.CreatedOn)
                .Select(o => new ShowOrderViewModel()
                {
                    Id = o.Id,
                    Restaurant = o.Restaurant.Name,
                    Status = o.OrderStatus.Name,
                    Amount = o.TotalAmount,
                    CreatedOn = o.CreatedOn.ToString(DataConstants.DateFormat),

                })
                .ToListAsync();

            return models;
        }
    }
}
