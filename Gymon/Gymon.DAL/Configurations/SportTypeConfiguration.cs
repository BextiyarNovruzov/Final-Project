using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymon.Core.Entities;

namespace Gymon.DAL.Configurations
{
    public class SportTypeConfiguration : IEntityTypeConfiguration<SportType>
    {
        public void Configure(EntityTypeBuilder<SportType> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            // TrainerSportType ile ilişkiyi tanımlama
            builder.HasMany(s => s.TrainerSportTypes)
                .WithOne(ts => ts.SportType)
                .HasForeignKey(ts => ts.SportTypeId);

            builder.HasMany(s => s.Appointments)
                .WithOne(a => a.SportType)
                .HasForeignKey(a => a.SportTypeId);

            // Trainer ile SportType arasındaki ilişkiyi tanımlama
            builder.HasMany(s => s.TrainerSportTypes)
                .WithOne(ts => ts.SportType)
                .HasForeignKey(ts => ts.SportTypeId);
        }
    }
}
