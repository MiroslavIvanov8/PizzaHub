using System.ComponentModel.DataAnnotations;

namespace PizzaHub.Infrastructure.Data.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
    }
}
