using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .HasOne(r => r.Admin)
                .WithOne(a => a.Restaurant)
                .HasForeignKey<Restaurant>(r => r.AdminId);

            var data = new SeedData();

            builder.HasData(new Restaurant[] { data.Restaurant});
        }
    }
}
