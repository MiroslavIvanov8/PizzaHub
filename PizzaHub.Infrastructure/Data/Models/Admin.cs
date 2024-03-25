namespace PizzaHub.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Restaurant))]
        public int? RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; } = null!;

    }
}
