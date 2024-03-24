using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Areas.Admin.Models.Order;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.Order;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IAdminService adminService;
        private readonly IRepository repository;

        public AdminController(IOrderService orderService, IAdminService adminService, IRepository repository)
        {
            this.orderService = orderService;
            this.adminService = adminService;
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowTodayOrders([FromQuery] AllTodayOrdersViewModel model)
        {
            IEnumerable<ShowOrderViewModel> todayOrders = await this.adminService.ShowTodayOrdersAsync(model.CurrentPage, 10);

            model.Orders = todayOrders;
            model.TotalOrdersToday = this.repository
                .AllReadOnly<Order>()
                .Count(o => o.CreatedOn.Date == DateTime.UtcNow.Date);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ShowPendingOrders([FromQuery] AllPendingTodayOrdersViewModel model)
        {
            IEnumerable<AdminOrderViewmodel> pendingOrders = await this.adminService.GetPendingOrdersAsync(model.CurrentPage);

            model.Orders = pendingOrders;
            model.TotalOrdersToday = this.repository
                .AllReadOnly<Order>()
                .Count(o => o.CreatedOn.Date == DateTime.UtcNow.Date);

            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> ShowPastOrders([FromQuery] AllPastOrdersViewModel model)
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> MarkOrderAccepted(int orderId)
        {
            await this.adminService.MarkOrderAcceptedAsync(orderId);

            return RedirectToAction(nameof(ShowPendingOrders));
        }
    }
}
