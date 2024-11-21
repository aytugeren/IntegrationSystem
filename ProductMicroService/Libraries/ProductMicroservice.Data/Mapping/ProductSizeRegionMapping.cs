using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Data.Mapping
{
	public class ProductSizeRegionMapping : IEntityTypeConfiguration<ProductSizeRegion>
	{
		public void Configure(EntityTypeBuilder<ProductSizeRegion> builder)
		{
			builder.ToTable("tblProductSizeRegion");

			builder.HasKey(x => x.Id);

			builder.Property(x => x.CreatedDateTime).HasDefaultValue(DateTime.Now);
			builder.Property(x => x.IsActive).HasDefaultValue(false);
			builder.Property(x => x.IsDeleted).HasDefaultValue(true);
			builder.Property(x => x.LogMessage).HasDefaultValue($"ProductSizeRegion is added on {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}");

			builder.HasOne(x => x.ProductSize)
				.WithMany(x => x.ProductSizeRegions)
				.HasForeignKey(x => x.ProductSizeId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
