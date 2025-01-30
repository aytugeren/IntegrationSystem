namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs
{
    public class UpdateProductSizeDTO
    {
        public Guid Id { get; set; }

        public string Barcode { get; set; }

        public string SizeCode { get; set; }

        public Guid ProductVariantId { get; set; }

        public Guid? SizeId { get; set; }
    }
}
