namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeRegionDTos
{
    public class AddProductSizeRegionDTO
    {
        public Guid ProductSizeId { get; set; }

        public int RegionId { get; set; }

        public int Quantity { get; set; }

    }
}
