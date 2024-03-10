using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHub.Infrastructure.Data.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
