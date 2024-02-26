using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHub.Infrastructure.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Items = new HashSet<OrderItem>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(CourierId))]
        public int CourierId { get; set; }
        public virtual Courier Courier { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        public int StatusId { get; set; }
        public OrderStatus Status { get; set; } = null!;

        public Receipt Receipt { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; }

    }
}
