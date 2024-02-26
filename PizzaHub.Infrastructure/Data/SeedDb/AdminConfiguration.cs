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
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder
                .HasOne(a => a.Restaurant)
                .WithOne(r => r.Admin)
                .HasForeignKey<Restaurant>(r => r.AdminId);

            var data = new SeedData();

            builder.HasData(new Admin[] { data.Admin });
        }
    }
}
