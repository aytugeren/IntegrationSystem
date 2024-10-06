using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class ProductPrice : BaseEntity
    {
        public Guid ProductId { get; set; }

        public decimal ListPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int CurrencyId { get; set; }

        public virtual ProductEntity Products { get; set; }
    }
}
