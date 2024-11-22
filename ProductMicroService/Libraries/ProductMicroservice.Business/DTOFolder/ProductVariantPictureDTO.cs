namespace ProductMicroservice.Business.DTOFolder
{
    public class ProductVariantPictureDTO : BaseEntityDTO
    {
        public Guid ProductVariantId { get; set; }

        public Guid PictureId { get; set; }

        public ProductVariantDTO ProductVariant { get; set; }

        public PictureDTO Picture { get; set; }
    }
}
