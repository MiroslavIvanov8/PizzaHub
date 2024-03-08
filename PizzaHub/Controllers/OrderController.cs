using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Infrastructure.Data.Models;


namespace PizzaHub.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly ICustomerService customerService;

        public OrderController(IRestaurantService restaurantService , ICustomerService customerService)
        {
            this.restaurantService = restaurantService;
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Order(int pizzaId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            MenuItemViewModel model = await this.restaurantService.GetItemAsync(pizzaId);

            return RedirectToAction("OrderDetails" ,"Order", model);
        }

        [HttpGet]
        public IActionResult OrderDetails(MenuItemViewModel model)
        {
            return View(model);
        }

        
        public Task<IActionResult> ConfirmOrder(int pizzaId, int quantity, string address)
        {
            
            return null;
        }
    }
}
