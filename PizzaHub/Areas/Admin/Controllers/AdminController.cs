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
        private readonly IAdminService adminService;
        private readonly IRepository repository;
        private readonly IOrderService orderService;

        public AdminController(IAdminService adminService, IRepository repository, IOrderService orderService)
        {
            this.adminService = adminService;
            this.repository = repository;
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
            return View();
        }
    }
}
