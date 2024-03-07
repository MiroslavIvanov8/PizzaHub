using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace PizzaHub.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IActionResult Add(int itemId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login");
            }

            
        }
    }
}
