using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Core.Contracts;
    using Core.ViewModels.Cart;
    using Extensions;

    using static MessageConstants.SuccessMessages;

    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ICartService cartService;
        private readonly IOrderService orderService;

        public OrderController(ICustomerService customerService, ICartService cartService, IOrderService orderService)
        {
            this.customerService = customerService;
            this.cartService = cartService;
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            ICollection<CartItemViewModel> models = await this.cartService.MyCartAsync(customerId);

            return View(models);

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(string address, string paymentMethod)
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            bool result = await this.orderService.CreateOrderFromCartAsync(customerId, address, paymentMethod);

            if (result == false)
            {
                return BadRequest();
            }

            ViewData["OrderAccepted"] = OrderSendSuccessfully;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(int orderId)
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            bool result = await this.orderService.CancelOrder(orderId, customerId);

            if (result == false)
            {
                return BadRequest();
            }

            TempData["CanceledOrder"] = string.Format(OrderCanceled, orderId);

            return RedirectToAction("TrackOrders", "Customer");
        }
    }
}
