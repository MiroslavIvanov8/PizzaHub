namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    public class Customer
    {
        public Customer()
        {
            this.OrdersHistory = new HashSet<Order>();
            this.CustomerCart = new HashSet<CustomerCart>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<Order> OrdersHistory { get; set; }

        public virtual ICollection<CustomerCart> CustomerCart { get; set; }

    }
}
