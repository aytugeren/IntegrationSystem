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
	public class ProductSizeMapping : IEntityTypeConfiguration<ProductSize>
	{
		public void Configure(EntityTypeBuilder<ProductSize> builder)
		{
			builder.ToTable("tblProductSize");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.CreatedDateTime).HasDefaultValue(DateTime.Now);
			builder.Property(x => x.IsActive).HasDefaultValue(false);
			builder.Property(x => x.IsDeleted).HasDefaultValue(true);
			builder.Property(x => x.LogMessage).HasDefaultValue($"Product is added on {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}");

			builder.HasOne(x => x.ProductVariant)
				.WithMany(x => x.ProductSizes)
				.HasForeignKey(x => x.ProductVariantId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.ProductSizeRegions)
				.WithOne(x => x.ProductSize)
				.HasForeignKey(x => x.ProductSizeId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
