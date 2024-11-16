using ProductMicroservice.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
