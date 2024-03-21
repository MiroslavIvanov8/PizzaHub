using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Infrastructure.Enums;

namespace PizzaHub.Core.Interfaces
{
    using Contracts;
    using Infrastructure.Data.Models;
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
                order.StatusId = OrderStatusEnum.InProgress;
            }

            await this.repository.SaveChangesAsync();
        }
    }
}
