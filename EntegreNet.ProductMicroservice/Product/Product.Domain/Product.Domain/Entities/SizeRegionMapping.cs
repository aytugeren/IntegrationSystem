using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class SizeRegionMapping : BaseEntity
    {
        public Guid ProductSizeId { get; set; }

        public int RegionId { get; set; }

        public int Quantity { get; set; }

        public virtual ProductSize ProductSize { get; set; }
    }
}
