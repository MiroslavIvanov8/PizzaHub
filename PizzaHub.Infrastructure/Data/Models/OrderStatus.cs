namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static PizzaHub.Infrastructure.Constants.DataConstants.OrderStatus;
    public class OrderStatus
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(StatusNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
