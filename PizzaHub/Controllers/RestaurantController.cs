using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using PizzaHub.Core.Contracts;
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
        public async Task<IActionResult> Menu()
        {
            IEnumerable<MenuItemViewModel> menu = await this.restaurantService.GetMenu();
            return View(menu);
        }
    }
}
