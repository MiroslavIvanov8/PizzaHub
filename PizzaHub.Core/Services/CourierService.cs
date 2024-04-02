using MessageConstants = PizzaHub.Infrastructure.Constants.MessageConstants;

namespace PizzaHub.Core.Services
{
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using ViewModels.MenuItem;
    using ViewModels.Order;
    using Infrastructure.Common;
    using Infrastructure.Constants;
    using Infrastructure.Data.Models;
    using Infrastructure.Enums;

    using static MessageConstants.AppEmailConstants;


    public class CourierService : ICourierService
    {
        private readonly IRepository repository;
        private readonly IOrderService orderService;
        private readonly ISendGridEmailSender emailSender;

        public CourierService(IRepository repository, IOrderService orderService, ISendGridEmailSender emailSender)
        {
            this.repository = repository;
            this.orderService = orderService;
            this.emailSender = emailSender;
        }
        public async Task<bool> CreateApplicationRequestAsync(string userId, string phoneNumber, string description)
        {
            try
            {
                if (await this.IsApplicantInLegalAge(userId))
                {

                    if (await this.repository.AllReadOnly<CourierApplicationRequest>().AnyAsync(r => r.UserId == userId))
                    {
                        return false;
                    }

                    CourierApplicationRequest request = new CourierApplicationRequest()
                    {
                        UserId = userId,
                        Description = description,
                        PhoneNumber = phoneNumber
                    };

                    await this.repository.AddAsync(request);
                    await this.repository.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        public async Task<bool> IsApplicantInLegalAge(string userId)
        {
            ApplicationUser? user = await this.repository.AllReadOnly<ApplicationUser>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                
                DateTime legalAgeDate = DateTime.Today.AddYears(-18);
                
                return user.BirthDate <= legalAgeDate;
            }

            // Return false if user is not found
            return false;
        }

        public async Task<OrderQueryServiceModel> ShowInProgressOrdersAsync(int currentPage, int ordersPerPage)
        {
            var inProgressOrders = await this.repository
                .AllReadOnly<Order>()
                .Where(o => o.OrderStatus.Name == "In Progress")
                .Select(o => new DetailedOrderViewModel()
                {
                    Id = o.Id,
                    Restaurant = o.Restaurant.Name,
                    Address = o.Address,
                    Amount = o.TotalAmount,
                    CreatedOn = o.CreatedOn.ToString(DataConstants.DateFormat),
                    Customer = o.Customer.User.FirstName + " " + o.Customer.User.LastName,
                    OrderItems = o.Items.Select(oi => new OrderMenuItemWithQuantityViewModel()
                    {
                        Id = oi.Id,
                        Name = oi.MenuItem.Name,
                        Quantity = oi.Quantity,
                    }).ToList(),
                    Status = o.OrderStatus.Name
                }).ToListAsync();

            var orders = inProgressOrders
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .ToList();

            var model = new OrderQueryServiceModel
            {
                OrdersCount = inProgressOrders.Count,
                Orders = orders
            };

            return model;
        }

        public async Task<bool> PickOrderAsync(int orderId, int courierId)
        {
            Order order = await this.orderService.GetOrderAsync(orderId);

            if (order != null)
            {
                order.OrderStatusId = (int)OrderStatusEnum.OutForDelivery;
                order.CourierId = courierId;

                string subject = "Out for Delivery!";
                await this.emailSender.SendEmailAsync(
                    FromAppEmail,
                    FromAppTeam,
                    order.Customer.User.Email,
                    subject,
                    OrderOutForDelivery);

                await this.repository.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<int> GetCourierId(string userId)
        {
            Courier? courier = await this.repository.AllReadOnly<Courier>()
                .FirstOrDefaultAsync(c => c.User.Id == userId);

            if (courier != null)
            {
                return courier.Id;
            }

            return 0;
        }
    }
}
