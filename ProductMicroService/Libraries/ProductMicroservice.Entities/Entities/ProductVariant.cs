using ProductMicroservice.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Entities.Entities
{
	public class ProductVariant : BaseEntity
	{
        public string ProductVariantName { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public string ProductVariantCode { get; set; }

        public Guid CargoId { get; set; }

        public Guid DeliveryDuration { get; set; }

        public string DeliveryOption { get; set; }

        public Product Product { get; set; }

        public ICollection<ProductSize> ProductSizes { get; set; }

        public ICollection<ProductVariantPicture> ProductVariantPictures { get; set; }
    }
}
