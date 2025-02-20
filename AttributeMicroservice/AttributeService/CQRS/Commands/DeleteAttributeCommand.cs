using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class DeleteAttributeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
