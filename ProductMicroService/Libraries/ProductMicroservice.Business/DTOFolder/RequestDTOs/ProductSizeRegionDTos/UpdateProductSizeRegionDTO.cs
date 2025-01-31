namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeRegionDTos
{
    public class UpdateProductSizeRegionDTO
    {
        public Guid Id { get; set; }

        public Guid ProductSizeId { get; set; }

        public int RegionId { get; set; }

        public int Quantity { get; set; }

    }
}
