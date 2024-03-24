
using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Core.Interfaces
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using Infrastructure.Data.Models;
    using PizzaHub.Infrastructure.Constants;
    using HouseRentingSystem.Infrastructure.Data.Common;
    using PizzaHub.Infrastructure.Enums;
    using System;


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

        public async Task<OrderQueryServiceModel> GetAllOrdersAsync(string status, FilterDays filterDays, int currentPage, int ordersPerPage)
        {
            var allOrders = this.repository.All<Order>().AsQueryable();

            if ((int)filterDays > 0)
            {
                var fromDate = DateTime.UtcNow.Date.AddDays(-(int)filterDays);
                allOrders = allOrders.Where(o => o.CreatedOn >= fromDate);
            }

            switch (status)
            {
                case "Pending":
                    allOrders = allOrders.Where(o => o.OrderStatus.Name == "Pending");
                    break;
                case "In Progress":
                    allOrders = allOrders.Where(o => o.OrderStatus.Name == "In Progress");
                    break;
                case "Out for Delivery":
                    allOrders = allOrders.Where(o => o.OrderStatus.Name == "Out for Delivery");
                    break;
                case "Delivered":
                    allOrders = allOrders.Where(o => o.OrderStatus.Name == "Delivered");
                    break;
                case "Canceled":
                    allOrders = allOrders.Where(o => o.OrderStatus.Name == "Canceled");
                    break;
                default: 
                    break;
            }

            var orders = allOrders
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ToList();

            var orderViewModels = new List<AdminOrderViewmodel>();

            foreach (var order in orders)
            {
                
                var orderViewModel = new AdminOrderViewmodel
                {
                    Id = order.Id,
                    Address = order.Address,
                    Restaurant = order.Restaurant.Name,
                    CreatedOn = order.CreatedOn.ToString(DataConstants.DateFormat),
                    Amount = order.TotalAmount,
                    Customer = order.Customer.User.UserName,
                    Status = order.OrderStatus.Name,
                    OrderItems = order.Items.Select(i => new OrderMenuItemWithQuantityViewModel()
                    {
                        Id = i.Id,
                        Name = i.MenuItem.Name,
                        Quantity = i.Quantity,
                    })
                };

                orderViewModels.Add(orderViewModel);
            }

            return new OrderQueryServiceModel()
            {
                OrdersCount = allOrders.Count(),
                Orders = orderViewModels
            };
        }

        public async Task<OrderQueryServiceModel> GetPendingOrdersAsync(int currentPage, int ordersPerPage)
        {
            var pendingOrders = await this.repository.All<Order>()
                .OrderBy(o => o.CreatedOn)
                .Where(o => o.CreatedOn.Date == DateTime.UtcNow.Date && o.OrderStatusId == (int)OrderStatusEnum.Pending)
                .ToListAsync();
            
            var orders = pendingOrders
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ToList();
            
            var orderViewModels = new List<AdminOrderViewmodel>();

            foreach (var order in orders)
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

            return new OrderQueryServiceModel()
            {
                OrdersCount = pendingOrders.Count,
                Orders = orderViewModels,
            };
        }

    }
}

