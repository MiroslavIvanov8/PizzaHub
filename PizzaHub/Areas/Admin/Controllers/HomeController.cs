﻿namespace PizzaHub.Areas.Admin.Controllers
{
    using Core.Contracts;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : AdminBaseController
    {
        private readonly IRestaurantService restaurantService;

        public HomeController()
        {
            
        }
        public HomeController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {
            var models = await this.restaurantService.GetMenuAsync();

            return View(models);
        }
        
    }
}
