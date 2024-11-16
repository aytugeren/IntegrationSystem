using ProductMicroservice.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Entities.Entities
{
	public class Product : BaseEntity
	{
        public string ProductName { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
