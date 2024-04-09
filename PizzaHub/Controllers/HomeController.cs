

using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Home;

namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using PizzaHub.Core.ViewModels;

    public class HomeController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IRestaurantService restaurantService,
            ILogger<HomeController> logger)
        {
            this.restaurantService = restaurantService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            if(User.IsInRole("Admin")) 
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            bool isCourier = User.IsInRole("Courier");

            var models = await this.restaurantService.ShowBestSellersAsync();
            HomeViewModel homeModel = new HomeViewModel()
            {
                IsCourier = isCourier,
                BestSellers = models
            };
            return View("Index", homeModel);
        }

        public IActionResult SureNotHungry()
        {
            Exception exeException = new Exception();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }
            if(statusCode == 401)
            {
                return View("Error401");
            }
            if(statusCode == 404)
            {
                return View("Error404");
            }
            if(statusCode == 500)
            {
                return View("Error500");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
