namespace ProductMicroservice.Business.DTOFolder
{
    public class ProductVariantSizeRegionDTO : BaseEntityDTO
    {
        public Guid ProductSizeId { get; set; }

        public int RegionId { get; set; }

        public int Quantity { get; set; }

        public ProductSizeDTO ProductSize { get; set; }
    }
}
