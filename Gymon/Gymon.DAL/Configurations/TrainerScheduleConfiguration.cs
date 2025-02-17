using Gymon.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Configurations
{
    public class TrainerScheduleConfiguration : IEntityTypeConfiguration<TrainerSchedule>
    {
        public void Configure(EntityTypeBuilder<TrainerSchedule> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Trainer)
                .WithMany(t => t.Schedules)
                .HasForeignKey(s => s.TrainerId);

            builder.Property(s => s.Day)
                .IsRequired();

            builder.Property(s => s.StartTime)
                .IsRequired();

            builder.Property(s => s.EndTime)
                .IsRequired();
        }
    }
}
