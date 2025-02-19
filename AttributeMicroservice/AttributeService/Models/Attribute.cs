namespace AttributeService.Models
{
    public class Attribute
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<AttributeValue> AttributeValues { get; set; } = new();
        public List<ProductAttribute> ProductAttributes { get; set; } = new();
    }
}
