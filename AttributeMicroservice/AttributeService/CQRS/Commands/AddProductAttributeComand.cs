using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class AddProductAttributeComand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid AttributeId { get; set; }
        public Guid? AttributeValueId { get; set; }
        public string? CustomValue { get; set; }
    }
}
