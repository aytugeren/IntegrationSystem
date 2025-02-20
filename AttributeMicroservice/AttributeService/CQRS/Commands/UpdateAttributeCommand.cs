using MediatR;

namespace AttributeService.CQRS.Commands
{
    public class UpdateAttributeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
