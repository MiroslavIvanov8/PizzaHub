namespace PizzaHub.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static PizzaHub.Infrastructure.Constants.DataConstants.Restaurant;
    public class Restaurant
    {
        public Restaurant()
        {
            this.MenuItems = new HashSet<MenuItem>();
            this.OrdersHistory = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;


        [ForeignKey(nameof(AdminId))]
        public int AdminId { get; set; } 
        public Admin Admin { get; set; } = null!;

        public ICollection<Order> OrdersHistory { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; } 
    }
}
