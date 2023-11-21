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
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.category_id).IsRequired(true);
            builder.Property(p => p.category_name).IsRequired(true);
        }
    }
}
