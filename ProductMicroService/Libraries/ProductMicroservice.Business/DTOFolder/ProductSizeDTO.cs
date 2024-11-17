namespace ProductMicroservice.Business.DTOFolder
{
    public class ProductSizeDTO : BaseEntityDTO
    {
        public string Barcode { get; set; }

        public string SizeCode { get; set; }

        public Guid ProductVariantId { get; set; }

        public ProductVariantDTO ProductVariant { get; set; }

        public ICollection<ProductVariantSizeRegionDTO> ProductSizeRegions { get; set; }
    }
}
