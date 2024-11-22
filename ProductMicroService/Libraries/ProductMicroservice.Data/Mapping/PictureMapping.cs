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
    public class PictureMapping : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("tblPicture");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedDateTime).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsActive).HasDefaultValue(false);
            builder.Property(x => x.IsDeleted).HasDefaultValue(true);
			builder.Property(x => x.LogMessage).HasDefaultValue($"Picture is added on {DateTime.Now.ToString("dd-MM-yyyy HH:mm")}");

            builder.HasMany(x => x.ProductVariantPictures)
                .WithOne(x => x.Picture)
                .HasForeignKey(x => x.PictureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
