using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IAdminService adminService;

        public AdminController(IOrderService orderService, IAdminService adminService)
        {
            this.orderService = orderService;
            this.adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowPendingOrders()
        {
            IEnumerable<AdminOrderViewmodel> orderViewModels = await this.orderService.GetPendingOrdersAsync();

            return View(orderViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> MarkOrderAccepted(int orderId)
        {
            await this.adminService.MarkOrderAcceptedAsync(orderId);

            return RedirectToAction(nameof(ShowPendingOrders));
        }
    }
}
