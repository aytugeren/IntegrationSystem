using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMicroservice.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Data.Mapping
{
	public class ProductVariantPictureMapping : IEntityTypeConfiguration<ProductVariantPicture>
	{
		public void Configure(EntityTypeBuilder<ProductVariantPicture> builder)
		{
			builder.ToTable("tblProductVariantPicture");

			builder.HasKey(x => new { x.ProductVariantId, x.PictureId });
			builder.HasOne(x => x.Picture)
				.WithMany(x => x.ProductVariantPictures)
				.HasForeignKey(x => x.PictureId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.ProductVariant)
				.WithMany(x => x.ProductVariantPictures)
				.HasForeignKey(x => x.ProductVariantId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
