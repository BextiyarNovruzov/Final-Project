using Gymon.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Context
{
    public class GymonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public GymonDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GymonDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
