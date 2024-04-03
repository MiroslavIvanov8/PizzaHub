using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;

namespace PizzaHub.Areas.Admin.Controllers
{
    public class OrderController : AdminBaseController
    {
        private readonly IOrderService orderService;
        private readonly IAdminService adminService;

        public OrderController(IOrderService orderService, IAdminService adminService)
        {
            this.orderService = orderService;
            this.adminService = adminService;
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
    }
}
