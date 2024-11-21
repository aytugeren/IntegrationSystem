using ProductMicroservice.Entities.Base;

namespace ProductMicroservice.Entities.Entities
{
	public class ProductSizeRegion : BaseEntity
	{
        public Guid ProductSizeId { get; set; }

        public int RegionId { get; set; }

        public int Quantity { get; set; }

        public ProductSize ProductSize { get; set; }
    }
}
