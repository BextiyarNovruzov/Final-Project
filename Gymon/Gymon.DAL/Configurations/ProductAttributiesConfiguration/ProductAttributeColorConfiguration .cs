using Gymon.Core.Entities.ProductAttributies;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.DAL.Configurations.ProductAttributiesConfiguration
{
    public class ProductAttributeColorConfiguration : IEntityTypeConfiguration<ProductAttributeColor>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeColor> builder)
        {
            builder.HasKey(pac => new { pac.ProductAttributeId, pac.ColorId });

            builder.HasOne(pac => pac.ProductAttribute)
                .WithMany(pa => pa.ProductAttributeColors)
                .HasForeignKey(pac => pac.ProductAttributeId);

            builder.HasOne(pac => pac.Color)
                .WithMany(c => c.ProductAttributeColors)
                .HasForeignKey(pac => pac.ColorId);

        }
    }
}

