using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Domain.Entities;

namespace Portal.Web.Models.Database.Configuration
{
    public class OrderConfiguration_MySQL : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(nameof(Order.DateTimeCreated))
                .HasDefaultValueSql("NOW(6)");
        }
    }
}
