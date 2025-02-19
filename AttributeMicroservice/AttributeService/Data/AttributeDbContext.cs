using AttributeService.Models;
using Microsoft.EntityFrameworkCore;

namespace AttributeService.Data
{
    public class AttributeDbContext : DbContext
    {
        public AttributeDbContext(DbContextOptions<AttributeDbContext> options) : base(options) { }

        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<Models.Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductAttribute>()
                .HasOne(p => p.Attribute)
                .WithMany(a => a.ProductAttributes)
                .HasForeignKey(p => p.AttributeId);

            modelBuilder.Entity<ProductAttribute>()
                .HasOne(p => p.AttributeValue)
                .WithMany()
                .HasForeignKey(p => p.AttributeValueId);

            modelBuilder.Entity<AttributeValue>()
                .HasOne(av => av.Attribute)
                .WithMany(a => a.AttributeValues)
                .HasForeignKey(av => av.AttributeId);
        }
    }
}
