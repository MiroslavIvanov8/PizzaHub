using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHub.Infrastructure.Data.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        [ForeignKey(nameof(MenuItem))]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }
    }
}
