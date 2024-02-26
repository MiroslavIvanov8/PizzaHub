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
    internal class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            var data = new SeedData();

            builder.HasData(new OrderStatus[] { data.FirstStatus, data.SecondStatus, data.ThirdStatus, data.ForthStatus});
        }
    }
}
