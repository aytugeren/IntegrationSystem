using Product.Domain.Common;

namespace Product.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string ProductName { get; set; }

        public Guid ProductMainId { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }

        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
    }
}
