using Gymon.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(500);

            builder.Property(p => p.Stock)
                .IsRequired();

            builder.Property(p => p.CoverImage)
                .IsRequired();

            builder.Property(p => p.Discount)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(p => p.CostPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(p => p.SellPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.   Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Images)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.ProductAttributes)
              .WithOne(a => a.Product)
              .HasForeignKey(a => a.ProductId);
        }
    }
}
