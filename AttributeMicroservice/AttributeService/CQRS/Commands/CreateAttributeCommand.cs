using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class CreateAttributeCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
