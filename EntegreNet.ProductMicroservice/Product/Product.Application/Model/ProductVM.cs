using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Model
{
    public class ProductVM
    {
        public string ProductName { get; set; }

        public Guid ProductMainId { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }
    }
}
