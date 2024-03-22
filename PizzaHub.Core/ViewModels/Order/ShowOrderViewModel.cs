using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Areas.Admin.Models.Order
{
    public class ShowOrderViewModel
    {
        public int Id { get; set; }
        public string Restaurant { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Amount { get; set; }

        public string CreatedOn { get; set; } = null!;
    }
}
