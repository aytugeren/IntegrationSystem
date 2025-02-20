using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class DeleteProductAttributeCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public Guid AttributeId { get; set; }
    }
}
