﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PizzaHub.Areas.Courier.Controllers
{
    [Area("Courier")]
    [Authorize(Roles = "Courier")]
    public class CourierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
