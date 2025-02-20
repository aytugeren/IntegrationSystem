using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class UpdateAttributeValueCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
    }
}
