using ProductMicroservice.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
