using ProductMicroservice.Entities.Base;

namespace ProductMicroservice.Entities.Entities
{
	public class ProductSize : BaseEntity
	{
        public string Barcode { get; set; }

        public string SizeCode { get; set; }

        public Guid ProductVariantId { get; set; }

        public ProductVariant ProductVariant { get; set; }

        public ICollection<ProductSizeRegion> ProductSizeRegions { get; set; }
    }
}
