using Microsoft.AspNetCore.Identity;
using DataConstants = PizzaHub.Infrastructure.Constants.DataConstants;
using MessageConstants = PizzaHub.Infrastructure.Constants.MessageConstants;

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
    using static MessageConstants.AppEmailConstants;

    public class AdminService : IAdminService
    {
        private readonly IRepository repository;
        private readonly IOrderService orderService;
        private readonly ISendGridEmailSender emailSender;

        public AdminService(IRepository repository, IOrderService orderService, ISendGridEmailSender emailSender)
        {
            this.repository = repository;
            this.orderService = orderService;
            this.emailSender = emailSender;
        }

        public async Task<MenuItemFormModel?> GetMenuItemFormAsync(int id)
        {
            MenuItemFormModel? item = await this.repository
                .All<MenuItem>()
                .Where(i => i.Id == id)
                .Select(i => new MenuItemFormModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Ingredients = i.Ingredients,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price
                }).FirstOrDefaultAsync();

            return item;
        }

        public async Task MarkOrderAcceptedAsync(int orderId)
        {
            Order? order = await this.repository.All<Order>().FirstOrDefaultAsync(o => o.Id == orderId);

            if (order != null)
            {
                order.OrderStatusId = (int)OrderStatusEnum.InProgress;

                await emailSender.SendEmailAsync(FromAppEmail,
                    FromAppTeam,
                    order.Customer.User.Email,
                    OrderAcceptedSuccessfully,
                    OrderAcceptedBody);
            }

            await this.repository.SaveChangesAsync();
        }

        public async Task<OrderQueryServiceModel> GetAllOrdersAsync(string status, FilterDays filterDays, int currentPage, int ordersPerPage)
        {
            var allOrders = this.repository.All<Order>().AsQueryable();

            if ((int)filterDays > 0)
            {
                var fromDate = DateTime.Now.Date.AddDays(-(int)filterDays + 1);
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

            var orders =  await allOrders
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ToListAsync();

            var orderViewModels = new List<DetailedOrderViewModel>();

            foreach (var order in orders)
            {
                
                var orderViewModel = new DetailedOrderViewModel
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
            
            var orderViewModels = new List<DetailedOrderViewModel>();

            foreach (var order in orders)
            {
                var orderItemsWithQuantity =
                    await this.orderService.GetOrderMenuItemWithQuantityViewmodelAsync(order.Id);

                var orderViewModel = new DetailedOrderViewModel
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
        
        public async Task<bool> ApproveCourierApplicationAsync(int id)
        {
            CourierApplicationRequest? request = await this.repository
                .All<CourierApplicationRequest>().Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (request != null)
            {
                Courier courier = new Courier()
                {
                    UserId = request.UserId,
                };


                IdentityUserRole<string> userRole = new IdentityUserRole<string>()
                {
                    RoleId = "22222222-2222-2222-2222-b893d8395082",
                    UserId = request.User.Id,
                };

                await this.repository.AddAsync(courier);
                await this.repository.AddAsync(userRole);
                await this.repository.Remove(request);
                await this.repository.SaveChangesAsync();

                string subject = "Your request has been approved!";
                await emailSender.SendEmailAsync(
                    FromAppEmail,
                    FromAppTeam,
                    request.User.Email,
                    subject,
                    CourierApprovalEmailMessage);
                return true;
            }

            return false;
        }

        public async Task<bool> DeclineCourierApplicationAsync(int id)
        {
            CourierApplicationRequest? request = await this.repository
                .All<CourierApplicationRequest>().Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (request != null)
            {
                await this.repository.Remove(request);
                await this.repository.SaveChangesAsync();

                string subject = "Courier Application Request Declined";
                await this.emailSender.SendEmailAsync(
                    FromAppEmail,
                    FromAppTeam,
                    request.User.Email,
                    subject,
                    CourierDeclinedEmailMessage);
                
                return true;
            }

            return false;
        }

        public async Task<int> AddMenuItemAsync(MenuItemFormModel model)
        {
            MenuItem menuItem = new MenuItem()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Ingredients = model.Ingredients,
                Price = model.Price,
                RestaurantId = 1
            };

            await this.repository.AddAsync(menuItem);
            await this.repository.SaveChangesAsync();

            return menuItem.Id;
        }

        public async Task<int> EditMenuItemAsync(MenuItemFormModel model)
        {
            MenuItem? item = await this.repository
                .All<MenuItem>()
                .Where(i => i.Id == model.Id)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Name = model.Name;
                item.ImageUrl = model.ImageUrl;
                item.Price = model.Price;
                item.Price = model.Price;

                return await this.repository.SaveChangesAsync();
            }

            return item.Id;
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            MenuItem? item = await this.repository
                .All<MenuItem>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.IsDeleted = !item.IsDeleted;
                await this.repository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<CourierApplicantModel> GetCourierApplicantsAsync(int id)
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

