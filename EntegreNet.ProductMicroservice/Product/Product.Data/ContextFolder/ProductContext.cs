using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Domain.Mapping;

namespace Product.Data.ContextFolder
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<ProductVariant> ProductVariants { get; set; }

        public DbSet<ProductVariantPicture> ProductVariantPicture { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<ProductSize> ProductSizes { get; set; }

        public DbSet<SizeRegionMapping> SizeRegionMappings { get; set; }

        public DbSet<ProductPrice> ProductPrices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductVariantConfiguration());
            modelBuilder.ApplyConfiguration(new ProductVariantPictureConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPriceConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeConfiguration());
            modelBuilder.ApplyConfiguration(new SizeRegionMappingConfiguration());
        }
    }
}
