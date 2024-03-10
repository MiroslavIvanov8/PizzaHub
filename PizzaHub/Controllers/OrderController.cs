using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels;
using PizzaHub.Extensions;


namespace PizzaHub.Controllers
{
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
            int customerId = await this.customerService.GetCustomerId(User.GetUserId());

            ICollection<CartItemViewModel> models = await this.cartService.MyCartAsync(customerId);

            return View(models);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(string address, string paymentMethod)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToPage("404");
            }

            int customerId = await this.customerService.GetCustomerId(User.GetUserId());

            bool result = await this.orderService.CreateOrderFromCartAsync(customerId, address, paymentMethod);

            return View(result);
        }
    }
}
