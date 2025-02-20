using AttributeService.CQRS.Commands;
using AttributeService.Data;
using AttributeService.Models;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class AddProductAttributeHandler : IRequestHandler<AddProductAttributeComand, Guid>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;

        public AddProductAttributeHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<Guid> Handle(AddProductAttributeComand request, CancellationToken cancellationToken)
        {
            var productAttribute = new ProductAttribute
            {
                ProductId = request.ProductId,
                AttributeId = request.AttributeId,
                AttributeValueId = request.AttributeValueId,
                CustomValue = request.CustomValue,
            };

            _context.ProductAttributes.Add(productAttribute);
            await _context.SaveChangesAsync();

            await _cache.RemoveAsync("productAttributes", cancellationToken);

            return productAttribute.Id;
        }
    }
}
