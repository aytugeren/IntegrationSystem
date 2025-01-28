namespace ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantDTOs
{
	public class AddProductVariantDTO
	{
		public string ProductVariantName { get; set; }

		public Guid ProductId { get; set; }

		public string Description { get; set; }

		public string ProductVariantCode { get; set; }

		public Guid CargoId { get; set; }

		public Guid DeliveryDuration { get; set; }

		public string DeliveryOption { get; set; }
	}
}
