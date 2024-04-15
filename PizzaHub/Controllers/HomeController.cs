using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Controllers
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using Core.Contracts;
    using Core.ViewModels.Home;
    using Core.ViewModels;
    using static DataConstants;

    public class HomeController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly IMemoryCache cache;

        public HomeController(IRestaurantService restaurantService
            ,IMemoryCache cache)
        {
            this.restaurantService = restaurantService;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            if(User.IsInRole("Admin")) 
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }
            
            if (cache.TryGetValue(CacheHomeKey, out HomeViewModel homeModel))
            {
               
            }
            else
            {

                bool isCourier = User.IsInRole("Courier");

                var models = await this.restaurantService.ShowBestSellersAsync();
                homeModel = new HomeViewModel()
                {
                    IsCourier = isCourier,
                    BestSellers = models
                };

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal);

                cache.Set(CacheHomeKey, homeModel, cacheEntryOptions);
            }
            
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
            //if(statusCode == 0)
            //{
            //    return View("Error500");
            //}

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
