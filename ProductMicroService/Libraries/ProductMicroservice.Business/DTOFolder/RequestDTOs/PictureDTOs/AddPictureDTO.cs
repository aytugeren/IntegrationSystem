using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.PictureDTOs
{
    public class AddPictureDTO
    {
        public string PictureName { get; set; }

        public string PictureUrl { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string PictureAltName { get; set; }

        public List<Guid> ProductVariantIds { get; set; }
    }
}
