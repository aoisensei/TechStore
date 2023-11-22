using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Techstore.Domain.Entities;

namespace Techstore.Infrastructure.Data.Configuration
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.order_id).IsRequired(true);
            builder.Property(p => p.order_date).IsRequired(true);
            builder.Property(p => p.total_price).IsRequired(true);

            builder.HasOne(p => p.user).
                WithMany(e => e.ds_order).
                HasForeignKey(e => e.user_id).
                OnDelete(DeleteBehavior.NoAction);
        }
    }
}
