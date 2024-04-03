using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Courier;

namespace PizzaHub.Areas.Admin.Controllers
{
    public class CourierController : Controller
    {
        private readonly IAdminService adminService;

        public CourierController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [HttpGet]
        public async Task<IActionResult> ShowCourierApplicants()
        {
            IEnumerable<CourierApplicantModel> models = await this.adminService.GetAllCourierApplicantsAsync();

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> CourierApplicantDetails(int id)
        {
            CourierApplicantModel model = await this.adminService.GetCourierApplicantsAsync(id);

            if (model != null)
            {
                return View(model);
            }

            return RedirectToAction(nameof(ShowCourierApplicants));
        }

        [HttpPost]
        public async Task<IActionResult> ApproveCourierApplicant(int id)
        {
            await this.adminService.ApproveCourierApplicationAsync(id);

            return RedirectToAction("ShowCourierApplicants", "Courier");
        }

        [HttpPost]
        public async Task<IActionResult> DeclineCourierApplicant(int id)
        {
            await this.adminService.DeclineCourierApplicationAsync(id);

            return RedirectToAction("ShowCourierApplicants", "Courier");
        }
    }
}
