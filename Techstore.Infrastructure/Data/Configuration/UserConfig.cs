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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.user_id).IsRequired(true);
            builder.Property(p => p.username).IsRequired(true);
            builder.Property(p => p.password).IsRequired(true);
            builder.Property(p => p.email).IsRequired(true);
            builder.Property(p => p.full_name).IsRequired(true);

        }
    }
}
