using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Mapping
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("tblProductVariant");
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.CreatedDateTime).HasDefaultValue(DateTime.Now);

            builder.HasOne<ProductEntity>(x => x.Product)
                .WithMany(x => x.ProductVariants)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pv => pv.ProductVariantPictures)
                   .WithOne(pvp => pvp.ProductVariant)
                   .HasForeignKey(pvp => pvp.ProductVariantId);

            builder.HasMany(x => x.ProductSizes)
                .WithOne(x => x.ProductVariant)
                .HasForeignKey(x => x.ProductVariantId);
        }
    }
}
