namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs
{
    public class AddProductSizeDTO
    {
        public string Barcode { get; set; }

        public string SizeCode { get; set; }

        public Guid ProductVariantId { get; set; }
    }
}
