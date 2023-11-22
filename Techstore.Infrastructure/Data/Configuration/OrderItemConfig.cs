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
    internal class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(p => p.order_item_id).IsRequired(true);
            builder.Property(p => p.quantity).IsRequired(true);

            builder.HasOne(p => p.order).
                WithMany(e => e.ds_orderItem).
                HasForeignKey(e => e.order_id).
                OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.product).
                WithMany(e => e.ds_orderItem).
                HasForeignKey(e => e.product_id).
                OnDelete(DeleteBehavior.NoAction);
        }
    }
}
