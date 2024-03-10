using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels;
using PizzaHub.Extensions;
using System.Threading.Tasks;


namespace PizzaHub.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrderController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ICartService cartService;

        public OrderController(ICustomerService customerService, ICartService cartService)
        {
            this.customerService = customerService;
            this.cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            int customerId = await this.customerService.GetCustomerId(User.GetUserId());

            ICollection<CartItemViewModel> models = await this.cartService.MyCartAsync(customerId);

            return View(models);
            
        }

        [HttpPost]
        public IActionResult CreateOrder(string address, string paymentMethod)
        {

            return null;
        }
    }
}
