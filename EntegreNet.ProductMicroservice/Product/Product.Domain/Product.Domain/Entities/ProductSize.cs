using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class ProductSize : BaseEntity
    {
        public int Barcode { get; set; }

        public Guid ProductVariantId { get; set; }

        public string SizeCode { get; set; }

        public virtual ProductVariant ProductVariant { get; set; }

        public virtual ICollection<SizeRegionMapping> SizeRegionMappings { get; set; }
    }
}
