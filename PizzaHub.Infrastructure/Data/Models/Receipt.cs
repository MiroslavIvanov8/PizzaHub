using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHub.Infrastructure.Data.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(OrderId))]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
