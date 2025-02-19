namespace AttributeService.Models
{
    public class AttributeValue
    {
        public Guid Id { get; set; }
        public Guid AttributeId { get; set; }
        public Attribute Attribute { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
