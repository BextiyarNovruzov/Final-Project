using Gymon.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Username)
            .IsUnique();
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.Property(x => x.Username)
            .HasMaxLength(32);
        builder.Property(x => x.Email)
            .HasMaxLength(64);
        builder.Property(x => x.ComplateName)
            .HasMaxLength(64);

    }
}
