using AttributeService.Models;
using MediatR;

namespace AttributeService.CQRS.Queries
{
    public class GetProductAttributeQuery : IRequest<List<ProductAttribute>>
    {
        public Guid ProductId { get; set; }
    }
}
