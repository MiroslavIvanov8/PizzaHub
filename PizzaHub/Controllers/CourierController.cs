using PizzaHub.Core.Contracts;
using PizzaHub.Extensions;
using PizzaHub.Infrastructure.Constants;

namespace PizzaHub.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static MessageConstants.ErrorMessages;
    using static MessageConstants.SuccessMessages;
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
            
            bool result = await this.courierService.CreateApplicationRequestAsync(form.UserId, form.PhoneNumber, form.Description);
            string message;
            if (result)
            {
                message = SuccessCourierRequestSubmission;
            }
            else
            {
                message = ErrorInCourierRequestMessage;
            }

            return RedirectToAction("ShowRequestSubmission", "Courier", new { message });
        }

        public IActionResult ShowRequestSubmission(string message)
        {
            ViewBag.Message = message;
            ViewBag.MessageType = message.Contains("successfully") ? "Success" :  "Error";

            return View();
        }

    }

}
