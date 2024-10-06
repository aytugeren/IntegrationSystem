using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Mapping
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("tblProductSize");

            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.CreatedDateTime).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.ProductVariant)
                .WithMany(x => x.ProductSizes)
                .HasForeignKey(x => x.ProductVariantId);

            builder.HasMany(x => x.SizeRegionMappings)
                .WithOne(x => x.ProductSize)
                .HasForeignKey(x => x.ProductSizeId);
        }
    }
}
