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
        builder.HasKey(u => u.Id);

        builder.Property(u => u.ComplateName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

   
        builder.HasMany(u => u.Appointments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        builder.HasMany(u => u.Orders)
     .WithOne(o => o.User)
     .HasForeignKey(o => o.UserId)
     .OnDelete(DeleteBehavior.Cascade);
    }
}
