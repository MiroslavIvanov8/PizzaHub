using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels;
using PizzaHub.Core.ViewModels.Cart;
using PizzaHub.Extensions;

namespace PizzaHub.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly ICartService cartService;
        private readonly ICustomerService customerService;

        public CartController(ICartService cartService, ICustomerService customerService)
        {
            this.cartService = cartService;
            this.customerService = customerService;
        }

        public async Task<IActionResult> Add(int itemId, int quantity)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            await this.cartService.AddToCartAsync(itemId, User.GetUserId(), quantity);
            
            return RedirectToAction("Menu", "Restaurant");
        }

        public async Task<IActionResult> MyCart()
        {
            int customerId = await this.customerService.GetCustomerId(User.GetUserId());

            ICollection<CartItemViewModel> models = await this.cartService.MyCartAsync(customerId);

            return View(models);
        }
    }
}
