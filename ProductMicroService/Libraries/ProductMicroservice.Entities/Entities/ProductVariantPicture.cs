namespace ProductMicroservice.Entities.Entities
{
	public class ProductVariantPicture
	{
            public Guid ProductVariantId { get; set; }

            public Guid PictureId { get; set; }

            public ProductVariant ProductVariant { get; set; }

            public Picture Picture { get; set; }
    }
}
