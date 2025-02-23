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
    public class ProductAttributeSizeConfiguration : IEntityTypeConfiguration<ProductAttributeSize>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeSize> builder)
        {
            builder.HasKey(pas => new { pas.ProductAttributeId, pas.SizeId });

            builder.HasOne(pas => pas.ProductAttribute)
                .WithMany(pa => pa.ProductAttributeSizes)
                .HasForeignKey(pas => pas.ProductAttributeId);

            builder.HasOne(pas => pas.Size)
                .WithMany(s => s.ProductAttributeSizes)
                .HasForeignKey(pas => pas.SizeId);

        }
    }

}
