using Microsoft.AspNetCore.Mvc;

namespace PizzaHub.Areas.Courier.Controllers
{
    public class CourierController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
