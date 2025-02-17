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
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Phone)
                .HasMaxLength(20);

            builder.Property(t => t.HourlyRate)
                .HasColumnType("decimal(18,2)");

            builder.HasMany(t => t.TrainerSportTypes)
                .WithOne(ts => ts.Trainer)
                .HasForeignKey(ts => ts.TrainerId);

            builder.HasMany(t => t.Schedules)
                .WithOne(s => s.Trainer)
                .HasForeignKey(s => s.TrainerId);

            builder.HasMany(t => t.Appointments)
                .WithOne(a => a.Trainer)
                .HasForeignKey(a => a.TrainerId);
        }
    }

}
