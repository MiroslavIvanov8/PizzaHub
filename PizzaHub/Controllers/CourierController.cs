namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Core.ViewModels.Courier;

    public class CourierController : Controller
    {
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BecomeCourier()
        {
            BecomeCourierForm form = new BecomeCourierForm();
            return View(form);
        }

        [Authorize()]
        [HttpPost]
        public async Task<IActionResult> BecomeCourier(BecomeCourierForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            return null;
        }
    }
}
