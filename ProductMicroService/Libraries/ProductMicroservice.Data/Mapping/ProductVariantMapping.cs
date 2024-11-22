using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Data.Mapping
{
	public class ProductVariantMapping : IEntityTypeConfiguration<ProductVariant>
	{
		public void Configure(EntityTypeBuilder<ProductVariant> builder)
		{
			builder.ToTable("tblProductVariant");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.CreatedDateTime).HasDefaultValueSql("NOW()");
			builder.Property(x => x.IsActive).HasDefaultValue(false);
			builder.Property(x => x.IsDeleted).HasDefaultValue(true);
			builder.Property(x => x.LogMessage).HasDefaultValue($"ProductVariant is added on {DateTime.Now.ToUniversalTime().ToString("dd-MM-yyyy HH:mm")}");

			builder.HasMany(x => x.ProductSizes)
				.WithOne(x => x.ProductVariant)
				.HasForeignKey(x => x.ProductVariantId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.ProductVariantPictures)
				.WithOne(x => x.ProductVariant)
				.HasForeignKey(x => x.ProductVariantId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
