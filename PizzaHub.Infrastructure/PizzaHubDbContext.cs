using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaHub.Infrastructure.Data.Models;
using PizzaHub.Infrastructure.Data.SeedDb;

namespace PizzaHub.Data
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
