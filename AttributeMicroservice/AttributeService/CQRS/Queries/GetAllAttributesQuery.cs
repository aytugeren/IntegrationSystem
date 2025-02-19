using MediatR;

namespace AttributeService.CQRS.Queries
{
    public class GetAllAttributesQuery : IRequest<List<Models.Attribute>>
    {
    }
}
