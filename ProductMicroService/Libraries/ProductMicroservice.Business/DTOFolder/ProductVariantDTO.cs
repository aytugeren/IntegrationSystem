
namespace ProductMicroservice.Business.DTOFolder
{
    public class ProductVariantDTO : BaseEntityDTO
    {
        public string ProductVariantName { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public string ProductVariantCode { get; set; }

        public Guid CargoId { get; set; }

        public Guid DeliveryDuration { get; set; }

        public string DeliveryOption { get; set; }

        public ProductDTO Product { get; set; }

        public ICollection<ProductSizeDTO> ProductSizes { get; set; }

        public ICollection<ProductVariantPictureDTO> ProductVariantPictures { get; set; }
    }
}
