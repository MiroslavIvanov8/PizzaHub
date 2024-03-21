using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
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

            //if we return null something went wrong
            await this.cartService.AddToCartAsync(itemId, User.GetUserId(), quantity);
            
            return RedirectToAction("Menu", "Restaurant");
        }

        [HttpGet]
        public async Task<IActionResult> MyCart()
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            ICollection<CartItemViewModel> models = await this.cartService.MyCartAsync(customerId);

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFromCart(int itemId)
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            await this.cartService.DeleteFromCartAsync(itemId, customerId);

            return RedirectToAction("MyCart");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int itemId, int newQuantity)
        {
            int customerId = await this.customerService.GetCustomerIdAsync(User.GetUserId());

            decimal newTotalAmount = await this.cartService.UpdateQuantityAsync(itemId, newQuantity, customerId);

            return RedirectToAction(nameof(MyCart));
        }
    }
}
