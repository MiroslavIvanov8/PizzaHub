    namespace PizzaHub.Controllers
    {
        using Microsoft.AspNetCore.Authorization;
        using Microsoft.AspNetCore.Mvc;

        using Core.ViewModels.Courier;

        [Authorize(Policy = "CustomerOnlyPolicy")]
        public class CourierController : Controller
        {
            
            [HttpGet]
            public async Task<IActionResult> BecomeCourier()
            {
                BecomeCourierForm form = new BecomeCourierForm();
                return View(form);
            }
            
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
