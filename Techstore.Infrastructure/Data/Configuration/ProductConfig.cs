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
    internal class ProductConfig
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.product_id).IsRequired(true);
            builder.Property(p => p.product_name).IsRequired(true);
            builder.Property(p => p.price).IsRequired(true);
            builder.Property(p => p.description).IsRequired(true);
            builder.Property(p => p.product_img).IsRequired(true);

            builder.HasOne(p => p.brand).
                WithMany(e => e.ds_product).
                HasForeignKey(p => p.brand_id).
                OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.category).
                WithMany(e => e.ds_product).
                HasForeignKey(p => p.category_id).
                OnDelete(DeleteBehavior.NoAction);

        }
    }
}
