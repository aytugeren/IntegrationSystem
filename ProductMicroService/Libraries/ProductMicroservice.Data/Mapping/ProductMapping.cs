using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Data.Mapping
{
	public class ProductMapping : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable("tblProduct");
			builder.HasKey(x => x.Id);
			
			builder.Property(x => x.CreatedDateTime).HasDefaultValueSql("NOW()");
			builder.Property(x => x.IsActive).HasDefaultValue(false);
			builder.Property(x => x.IsDeleted).HasDefaultValue(true);
			builder.Property(x => x.LogMessage).HasDefaultValue($"Product is added on {DateTime.Now.ToUniversalTime().ToString("dd-MM-yyyy HH:mm")}");

			builder.HasMany(x => x.ProductVariants)
				.WithOne(x => x.Product)
				.HasForeignKey(x => x.ProductId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
