using Product.Domain.Common;
using Product.Domain.Common.Enums;

namespace Product.Domain.Entities
{
    public class ProductVariant : BaseEntity
    {
        public string ProductVariantName { get; set; }

        public Guid ProductId { get; set; }

        public string Description { get; set; }

        public string ProductVariantCode { get; set; }

        public Guid CargoId { get; set; }

        public int? DeliveryDuration { get; set; }

        public DeliveryEnum? DeliveryOption { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual ICollection<ProductVariantPicture> ProductVariantPictures { get; set; }

        public virtual ICollection<ProductSize> ProductSizes { get; set; }
    }
}
