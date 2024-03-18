using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaHub.Infrastructure.Data.Models;

namespace PizzaHub.Infrastructure.Data.SeedDb
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder
                .HasOne(a => a.Restaurant)
                .WithMany(r => r.Admins)
                .HasForeignKey(a => a.RestaurantId)
                .IsRequired(false);

            var data = new SeedData();

            builder.HasData(new Admin[] { data.Admin });
        }
    }
}
