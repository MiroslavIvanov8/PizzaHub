using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaHub.Core.ViewModels.MenuItem;

namespace PizzaHub.Core.ViewModels.Home
{
    public class HomeViewModel
    {
        public bool IsCourier { get; set; } = false;
        public IEnumerable<MenuItemWithImageAndQuantity> BestSellers { get; set; } = null!;
    }
}
