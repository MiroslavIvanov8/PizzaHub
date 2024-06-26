﻿namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PizzaHub.Core.Contracts;
    using PizzaHub.Core.ViewModels.MenuItem;

    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
        public async Task<IActionResult> Menu(string? searchTerm)
        {
            IEnumerable<MenuItemViewModel> menu = await this.restaurantService.GetMenuAsync(searchTerm);

            return View(menu);
        } 
    }
}
