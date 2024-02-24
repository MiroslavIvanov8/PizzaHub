namespace PizzaHub.Infrastructure.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Courier
    {
        public Courier()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } 
    }
}
