using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class DeleteAttributeValueCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
