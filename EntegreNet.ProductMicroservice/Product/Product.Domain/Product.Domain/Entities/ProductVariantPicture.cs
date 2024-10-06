using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class ProductVariantPicture : BaseEntity
    {
        public Guid ProductVariantId { get; set; }

        public Guid PictureId { get; set; }

        public Picture Picture { get; set; }

        public ProductVariant ProductVariant { get; set; }
    }
}
