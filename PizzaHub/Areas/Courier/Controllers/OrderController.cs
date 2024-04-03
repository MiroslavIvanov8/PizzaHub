using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Extensions;

using static PizzaHub.Infrastructure.Constants.MessageConstants.AppEmailConstants;
using static PizzaHub.Infrastructure.Constants.MessageConstants.SuccessMessages;
namespace PizzaHub.Areas.Courier.Controllers
{
    public class OrderController : CourierBaseController
    {
        private readonly ICourierService courierService;
        private readonly IOrderService orderService;
        private readonly ISendGridEmailSender emailSender;

        public OrderController(ICourierService courierService, IOrderService orderService, ISendGridEmailSender emailSender)
        {
            this.courierService = courierService;
            this.orderService = orderService;
            this.emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> PickOrders([FromQuery]AllOrdersViewModel model)
        {
            OrderQueryServiceModel inProgressOrders = await this.courierService.ShowInProgressOrdersAsync(model.CurrentPage,model.OrdersPerPage);

            model.Orders = inProgressOrders.Orders;
            model.TotalOrders = inProgressOrders.OrdersCount;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PickOrder(int id)
        {
            int courierId = await this.courierService.GetCourierId(User.GetUserId());
            bool result = await this.courierService.PickOrderAsync(id, courierId);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("PickOrders");
        }

        [HttpGet]
        public async Task<IActionResult> ShowPickedOrders()
        {
            var pickedOrders = await this.courierService.ShowPickedOrdersAsync(await this.courierService.GetCourierId(User.GetUserId()));
            
            return View(pickedOrders);
        }
        
        public async Task<IActionResult> ViewOrderDetails(int orderId)
        {
            DetailedOrderViewModel? detailedOrder = await this.orderService.GetDetailedOrderViewModelAsync(orderId);

            if (detailedOrder == null)
            {
                return BadRequest();
            }

            return View(detailedOrder);
        }

        [HttpPost]
        public async Task<IActionResult> MarkOnAddress(int orderId)
        {
            string subject = "Delivery on Address!";
            var order = await this.orderService.GetOrderAsync(orderId);

            if (order == null)
            {
                return BadRequest();
            }

            await this.emailSender.SendEmailAsync(
                FromAppEmail,
                FromAppTeam,
                order.Customer.User.Email,
                subject,
                CourierOnAddress);

            TempData["Message"] = CustomerNotifiedCourierAtLocation;

            return RedirectToAction("ViewOrderDetails", "Order", new { orderId = order.Id });
        }
    }
}
