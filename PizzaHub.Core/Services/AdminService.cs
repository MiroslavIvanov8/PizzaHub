namespace PizzaHub.Core.Services
{
    using Microsoft.EntityFrameworkCore;
    using Contracts;
    using ViewModels.Courier;
    using ViewModels.MenuItem;
    using ViewModels.Order;
    using Infrastructure.Common;
    using Infrastructure.Constants;
    using Infrastructure.Data.Models;
    using Infrastructure.Enums;

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

        public async Task<IEnumerable<CourierApplicantModel>> GetAllCourierApplicantsAsync()
        {
            return await this.repository.All<CourierApplicationRequest>().Select(r => new CourierApplicantModel()
            {
                Id = r.Id,
                FullName = r.User.FirstName + " " + r.User.LastName,
                Age = DateTime.Now.Year - r.User.BirthDate.Year,
                Email = r.User.Email,
                PhoneNumber = r.PhoneNumber,
            }).ToListAsync();
        }

        public async Task<CourierApplicantModel> GetCourierApplicant(int id)
        {
            CourierApplicantModel? model =  await this.repository.All<CourierApplicationRequest>().Where(r => r.Id == id).Select(r => new CourierApplicantModel()
            {
                Id = r.Id,
                FullName = r.User.FirstName + " " + r.User.LastName,
                Age = DateTime.Now.Year - r.User.BirthDate.Year,
                Email = r.User.Email,
                PhoneNumber = r.PhoneNumber,
                Description = r.Description
            }).FirstOrDefaultAsync();

            return model;
        }
    }
}

