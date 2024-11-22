namespace ProductMicroservice.Business.DTOFolder.RequestDTOs
{
    public class AddProductDTO
    {
        public string ProductName { get; set; }

        public Guid BrandId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal VatRate { get; set; }

        public string ProductMainCode { get; set; }
    }
}
