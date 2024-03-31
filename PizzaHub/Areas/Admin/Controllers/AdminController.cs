using PizzaHub.Core.ViewModels.Courier;
using PizzaHub.Core.ViewModels.MenuItem;
using PizzaHub.Infrastructure.Data.Models;

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
        private readonly IRestaurantService restaurantService;

        public AdminController(IAdminService adminService, IOrderService orderService, IRestaurantService restaurantService)
        {
            this.adminService = adminService;
            this.orderService = orderService;
            this.restaurantService = restaurantService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {
            var models = await this.restaurantService.GetMenuAsync();

            return View(models);
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

        [HttpGet]
        public async Task<IActionResult> AddMenuItem()
        {
            MenuItemFormModel model = new MenuItemFormModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddMenuItem(MenuItemFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.adminService.AddMenuItemAsync(model);

            return RedirectToAction("Menu", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> EditMenuItem(int id)
        {
            MenuItemFormModel? item = await this.adminService.GetMenuItemFormAsync(id);
            if (item == null)
            {
                return BadRequest();
            }

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditMenuItem(MenuItemFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.adminService.EditMenuItemAsync(model);

            return RedirectToAction("Menu", "Admin");
        }

    }
}
