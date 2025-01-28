namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantDTOs
{
	public class UpdateProductVariantDTO
	{
        public Guid Id { get; set; }

        public string ProductVariantName { get; set; }

		public string Description { get; set; }

		public string ProductVariantCode { get; set; }

		public Guid CargoId { get; set; }

		public Guid DeliveryDuration { get; set; }

		public string DeliveryOption { get; set; }
	}
}
