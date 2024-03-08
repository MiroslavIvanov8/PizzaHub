using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    public class CustomerCartConfiguration : IEntityTypeConfiguration<CustomerCart>
    {
        public void Configure(EntityTypeBuilder<CustomerCart> builder)
        {
           builder.HasKey(ck => new { ck.CustomerId , ck.MenuItemId});

           builder.HasOne(ck => ck.Customer)
               .WithMany(c => c.CustomerCart)
               .OnDelete(DeleteBehavior.NoAction);

           builder.HasOne(ck => ck.MenuItem)
               .WithMany(m => m.CustomerCart)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
