using Product.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Picture : BaseEntity
    {
        public string PictureName { get; set; }

        public string PictureUrl { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string PictureAltName { get; set; }

        public virtual ICollection<ProductVariantPicture> ProductVariantPictures { get; set; }
    }
}
