using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using static PizzaHub.Infrastructure.Constants.MessageConstants.AppEmailConstants;
using static PizzaHub.Infrastructure.Constants.MessageConstants.SuccessMessages;
namespace PizzaHub.Areas.Courier.Controllers
{
    public class CourierController : CourierBaseController
    {
        private readonly IOrderService orderService;
        private readonly ISendGridEmailSender emailSender;

        public CourierController(IOrderService orderService, ISendGridEmailSender emailSender)
        {
            this.orderService = orderService;
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> MarkOrderDelivered(int orderId)
        {
            return null;
        }

    }
}
