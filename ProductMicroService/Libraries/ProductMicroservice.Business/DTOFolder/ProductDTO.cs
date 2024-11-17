namespace ProductMicroservice.Business.DTOFolder
{
    public class ProductDTO : BaseEntityDTO
    {
        public string ProductName { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }

        public ICollection<ProductVariantDTO> ProductVariants { get; set; }
    }
}
