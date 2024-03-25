using Microsoft.AspNetCore.Mvc;

namespace PizzaHub.Areas.Courier.Controllers
{
    public class CourierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
