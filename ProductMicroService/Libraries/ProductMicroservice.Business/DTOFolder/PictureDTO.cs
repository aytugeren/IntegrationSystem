namespace ProductMicroservice.Business.DTOFolder
{
    public class PictureDTO : BaseEntityDTO
    {
        public string PictureName { get; set; }

        public string PictureUrl { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string PictureAltName { get; set; }

        public ICollection<ProductVariantPictureDTO> ProductVariantPictures { get; set; }
    }
}
