using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Infrastructure.Data.Models;
using PizzaHub.Infrastructure.Data.SeedDb;

namespace PizzaHub.Infrastructure
{
    public class PizzaHubDbContext : IdentityDbContext
    {
        public PizzaHubDbContext(DbContextOptions<PizzaHubDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Courier> Couriers { get; set; } = null!;
        public DbSet<Admin> Admins { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;

        public DbSet<Receipt> Receipts { get; set; } = null!;

        public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;

        public DbSet<CustomerCart> CustomerCart { get; set; } = null!;

        public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new AdminConfiguration());
            builder.ApplyConfiguration(new CourierConfiguration());
            builder.ApplyConfiguration(new MenuItemConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderStatusConfiguration());
            builder.ApplyConfiguration(new ReceiptConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new CustomerCartConfiguration());
            builder.ApplyConfiguration(new PaymentMethodsConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
