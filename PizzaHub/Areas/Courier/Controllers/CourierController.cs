using Microsoft.AspNetCore.Mvc;

namespace PizzaHub.Areas.Courier.Controllers
{
    public class CourierController : CourierBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
