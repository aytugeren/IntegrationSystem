using AttributeService.Models;
using MediatR;

namespace AttributeService.CQRS.Queries
{
    public class GetAttributeValuesQuery : IRequest<List<AttributeValue>>
    {
        public Guid AttributeId { get; set; }
    }
}
