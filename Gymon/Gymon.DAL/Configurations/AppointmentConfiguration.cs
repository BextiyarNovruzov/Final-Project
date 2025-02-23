using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId);
            builder.Property(u => u.Phone)
                .HasMaxLength(20);

            builder.HasOne(a => a.Trainer)
                .WithMany(t => t.Appointments)
                .HasForeignKey(a => a.TrainerId);

            builder.HasOne(a => a.SportType)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.SportTypeId);

            builder.Property(a => a.AppointmentDate)
            .IsRequired();

            builder.Property(a => a.Status)
                  .IsRequired() // Make it required
                  .HasConversion<string>() // Store as string
                  .HasMaxLength(20); // Specify max length
        
        builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}

