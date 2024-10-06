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
    public class ProductVariantPictureConfiguration : IEntityTypeConfiguration<ProductVariantPicture>
    {
        public void Configure(EntityTypeBuilder<ProductVariantPicture> builder)
        {
            builder.ToTable("tblProductVariantPictures");
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.CreatedDateTime).HasDefaultValue(DateTime.Now);

            builder.HasKey(pvp => new { pvp.ProductVariantId, pvp.PictureId });

            // Bir ProductVariantPicture'ın bir ProductVariant'ı olabilir
            builder.HasOne(pvp => pvp.ProductVariant)
                   .WithMany(pv => pv.ProductVariantPictures)
                   .HasForeignKey(pvp => pvp.ProductVariantId);

            // Bir ProductVariantPicture'ın bir Picture'ı olabilir
            builder.HasOne(pvp => pvp.Picture)
                   .WithMany(p => p.ProductVariantPictures)
                   .HasForeignKey(pvp => pvp.PictureId);
        }
    }
}
