using Gymon.Core.Entities;
using Gymon.Core.Entities.ProductAttributies;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; } // Add the Reviews DbSet
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductAttributeColor> ProductAttributeColors { get; set; }
        public DbSet<ProductAttributeSize> ProductAttributeSizes { get; set; }




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
