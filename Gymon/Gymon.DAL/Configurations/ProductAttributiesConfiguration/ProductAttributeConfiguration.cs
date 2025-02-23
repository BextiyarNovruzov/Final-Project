
namespace Gymon.DAL.Configurations.ProductAttributiesConfiguration;

using Gymon.Core.Entities.ProductAttributies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.HasKey(pa => pa.Id);

        builder.HasMany(pa => pa.ProductAttributeColors)
            .WithOne(pac => pac.ProductAttribute)
            .HasForeignKey(pac => pac.ProductAttributeId)
            .OnDelete(DeleteBehavior.Cascade); // Delete behavior can be set based on your requirements

        builder.HasMany(pa => pa.ProductAttributeSizes)
            .WithOne(pas => pas.ProductAttribute)
            .HasForeignKey(pas => pas.ProductAttributeId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
