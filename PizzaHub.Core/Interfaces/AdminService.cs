
using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Infrastructure.Data.Models;
    using PizzaHub.Infrastructure.Constants;
    using HouseRentingSystem.Infrastructure.Data.Common;
    using PizzaHub.Infrastructure.Enums;


    public class AdminService : IAdminService
    {
        private IRepository repository;
        private readonly IOrderService orderService;

        public AdminService(IRepository repository, IOrderService orderService)
        {
            this.repository = repository;
            this.orderService = orderService;
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

        public async Task<IEnumerable<ShowOrderViewModel>> ShowTodayOrdersAsync(int currentPage, int ordersPerPage)
        {
            //All orders that go with today filter
            var ordersToShow = await this.repository.AllReadOnly<Order>()
                .OrderByDescending(o => o.CreatedOn)
                .Where(o => o.CreatedOn.Date == DateTime.UtcNow.Date)
                .Select(o => new ShowOrderViewModel()
                {
                    Id = o.Id,
                    Restaurant = o.Restaurant.Name,
                    Status = o.OrderStatus.Name,
                    Amount = o.TotalAmount,
                    CreatedOn = o.CreatedOn.ToString(DataConstants.DateFormat),

                })
                .ToListAsync();

            var orders = ordersToShow
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ToList();


            return orders;
        }

        public async Task<IEnumerable<AdminOrderViewmodel>> GetPendingOrdersAsync(int currentPage, int ordersPerPage)
        {
            var pendingOrders = await this.repository.All<Order>()
                .Where(o => o.CreatedOn.Date == DateTime.UtcNow.Date && o.OrderStatusId == (int)OrderStatusEnum.Pending)
                .ToListAsync();

            var orderViewModels = new List<AdminOrderViewmodel>();

            foreach (var order in pendingOrders)
            {
                var orderItemsWithQuantity =
                    await this.orderService.GetOrderMenuItemWithQuantityViewmodelAsync(order.Id);

                var orderViewModel = new AdminOrderViewmodel
                {
                    Id = order.Id,
                    Address = order.Address,
                    Restaurant = order.Restaurant.Name,
                    CreatedOn = order.CreatedOn.ToString(DataConstants.DateFormat),
                    Amount = order.TotalAmount,
                    Customer = order.Customer.User.UserName,
                    Status = order.OrderStatus.Name,
                    OrderItems = orderItemsWithQuantity
                };

                orderViewModels.Add(orderViewModel);
            }

            var orders = orderViewModels
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ToList();

            return orders;
        }
    }
}
