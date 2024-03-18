using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    internal class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder
                .HasMany(r => r.Admins)
                .WithOne(a => a.Restaurant);

            var data = new SeedData();

            builder.HasData(new Restaurant[] { data.Restaurant});
            
        }
    }
}
