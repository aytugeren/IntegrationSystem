namespace AttributeService.Models
{
    public class ProductAttribute
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid AttributeId { get; set; }

        public Attribute Attribute{ get; set; }

        public Guid AttributeValueId { get; set; }

        public AttributeValue AttributeValue { get; set; }

        public string? CustomValue { get; set; }
    }
}
