using PizzaHub.Core.ViewModels.Courier;

namespace PizzaHub.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Core.Contracts;
    using Core.ViewModels.Order;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;
        private readonly IOrderService orderService;

        public AdminController(IAdminService adminService, IOrderService orderService)
        {
            this.adminService = adminService;
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllOrders([FromQuery] AllOrdersViewModel model)
        {
            OrderQueryServiceModel allOrders = await this.adminService
                .GetAllOrdersAsync(model.Status, model.FilterDays, model.CurrentPage, 10);
            
            model.Statuses = await this.orderService.GetStatusNamesAsync();

            model.TotalOrders = allOrders.OrdersCount;
            model.Orders = allOrders.Orders;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTodayPendingOrders([FromQuery] AllOrdersViewModel model)
        {
            OrderQueryServiceModel pendingOrders = await this.adminService.GetPendingOrdersAsync(model.CurrentPage);

            model.Orders = pendingOrders.Orders;
            model.TotalOrders = pendingOrders.OrdersCount;

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> MarkOrderAccepted(int orderId)
        {
            await this.adminService.MarkOrderAcceptedAsync(orderId);

            return RedirectToAction(nameof(ShowTodayPendingOrders));
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

            return RedirectToAction("ShowCourierApplicants", "Admin");
        }

        [HttpPost]
        public async Task<IActionResult> DeclineCourierApplicant(int id)
        {
            await this.adminService.DeclineCourierApplicationAsync(id);

            return RedirectToAction("ShowCourierApplicants", "Admin");
        }
    }
}
