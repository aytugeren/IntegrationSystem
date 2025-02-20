using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class CreateAttributeValueCommand : IRequest<Guid>
    {
        public Guid AttributeId { get; set; }

        public string Value { get; set; }
    }
}
