using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Data.Mapping;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Data
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<ProductSize> ProductSizes { get; set; }

		public DbSet<ProductSizeRegion> ProductSizeRegions { get; set; }

		public DbSet<Picture> Pictures { get; set; }

        public DbSet<ProductVariantPicture> ProductVariantPictures { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductMapping());
			modelBuilder.ApplyConfiguration(new ProductVariantMapping());
			modelBuilder.ApplyConfiguration(new ProductSizeMapping());
			modelBuilder.ApplyConfiguration(new ProductVariantPictureMapping());
			modelBuilder.ApplyConfiguration(new ProductSizeRegionMapping());
			modelBuilder.ApplyConfiguration(new PictureMapping());
		}
	}
}
