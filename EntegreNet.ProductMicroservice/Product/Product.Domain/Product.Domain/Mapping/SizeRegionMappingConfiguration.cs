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
    public class SizeRegionMappingConfiguration : IEntityTypeConfiguration<SizeRegionMapping>
    {
        public void Configure(EntityTypeBuilder<SizeRegionMapping> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("tblSizeRegionMappings");

            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.Property(p => p.CreatedDateTime).HasDefaultValue(DateTime.Now);

            builder.HasOne(x => x.ProductSize)
                .WithMany(x => x.SizeRegionMappings)
                .HasForeignKey(x => x.ProductSizeId);
        }
    }
}
