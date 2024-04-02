

namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using PizzaHub.Core.ViewModels;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(User.IsInRole("Admin")) 
            {
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            if (User.IsInRole("Courier"))
            {
                return RedirectToAction("OrderOrDeliver", "Courier");
            }

            return View();
        }

        public IActionResult SureNotHungry()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
