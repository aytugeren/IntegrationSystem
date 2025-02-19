using AttributeService.CQRS.Queries;
using AttributeService.Data;
using AttributeService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AttributeService.Handlers
{
    public class GetProductAttributesHandler : IRequestHandler<GetProductAttributeQuery, List<ProductAttribute>>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;

        public GetProductAttributesHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<ProductAttribute>> Handle(GetProductAttributeQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = "productAttributes";
            var cachedProductAttributes = await _cache.GetStringAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedProductAttributes))
            {
                return JsonSerializer.Deserialize<List<ProductAttribute>>(cachedProductAttributes);
            }

            var result = await _context.ProductAttributes
                .Include(pa => pa.Attribute)
                .Include(pa => pa.AttributeValue)
                .Where(pa => pa.ProductId == request.ProductId)
                .ToListAsync(cancellationToken);

            if (result.Any())
            {
                var serializedProductAttributes = JsonSerializer.Serialize(result);
                await _cache.SetStringAsync(cacheKey, serializedProductAttributes, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)  // 30 dakika cache
                });
            }

            return result;
        }
    }
}
