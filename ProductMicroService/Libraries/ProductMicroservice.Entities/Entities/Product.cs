using ProductMicroservice.Entities.Base;

namespace ProductMicroservice.Entities.Entities
{
	public class Product : BaseEntity
	{
        public string ProductName { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
