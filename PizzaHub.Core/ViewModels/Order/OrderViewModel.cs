using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Core.ViewModels.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.OrderItems = new List<string>();
        }
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string Status { get; set; }

        public IEnumerable<string> OrderItems { get; set; }
    }
}
