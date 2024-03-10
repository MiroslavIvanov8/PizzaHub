using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHub.Infrastructure.Data.Models
{
    public class CustomerCart
    {
        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(MenuItem))]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
