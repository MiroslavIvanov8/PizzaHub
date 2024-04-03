using Microsoft.AspNetCore.Mvc;
using PizzaHub.Core.Contracts;
using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Areas.Admin.Controllers
{
    public class MenuItemController : HomeController
    {
        private readonly IAdminService adminService;

        public MenuItemController(IAdminService adminService)
        {
            this.adminService = adminService;
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

        [HttpGet]
        public async Task<IActionResult> DeleteMenuitem(int id)
        {
            MenuItemFormModel? model = await this.adminService.GetMenuItemFormAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmRemoveMenuItem(int id)
        {
            bool result = await this.adminService.DeleteMenuItemAsync(id);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction("Menu", "Admin");
        }
    }
}
