    using PizzaHub.Core.Contracts;
    using PizzaHub.Extensions;

    namespace PizzaHub.Controllers
    {
        using Microsoft.AspNetCore.Authorization;
        using Microsoft.AspNetCore.Mvc;

        using Core.ViewModels.Courier;

        [Authorize(Policy = "CustomerOnlyPolicy")]
        public class CourierController : Controller
        {
            private readonly ICourierService courierService;

            public CourierController(ICourierService courierService)
            {
                this.courierService = courierService;
            }
            
            [HttpGet]
            public async Task<IActionResult> BecomeCourier()
            {
                BecomeCourierForm form = new BecomeCourierForm();
                return View(form);
            }
            
            [HttpPost]
            public async Task<IActionResult> BecomeCourier(BecomeCourierForm form)
            {
                form.UserId = User.GetUserId();

                if (!ModelState.IsValid)
                {
                    return View(form);
                }

                bool result =
                    await this.courierService.CreateApplicationRequestAsync(form.UserId, form.PhoneNumber,
                        form.Description);

                if (result == true)
                {
                    // Successfully submitted request to become a courier
                }
                else
                {
                    //Something went wrong with submitting your request
                }

                return null;
            }
        }
    }
