using Gymon.Core.Entities;
using Gymon.Core.Enums;
using Gymon.DAL.Configurations;
using Gymon.DAL.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Context
{
    public class GymonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerSchedule> TrainerSchedule { get; set; }
        public DbSet<TrainerSportType> TrainerSportTypes { get; set; }

        public GymonDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GymonDbContext).Assembly);
            base.OnModelCreating(builder);

            // Configurations
            builder.ApplyConfiguration(new AppointmentConfiguration());
            builder.ApplyConfiguration(new TrainerConfiguration());
            builder.ApplyConfiguration(new TrainerScheduleConfiguration());
            builder.ApplyConfiguration(new SportTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
