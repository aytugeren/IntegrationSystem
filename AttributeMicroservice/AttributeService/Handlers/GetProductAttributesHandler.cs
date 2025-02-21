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
        private readonly ILogger<GetProductAttributesHandler> _logger;

        public GetProductAttributesHandler(AttributeDbContext context, IDistributedCache cache, ILogger<GetProductAttributesHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<List<ProductAttribute>> Handle(GetProductAttributeQuery request, CancellationToken cancellationToken)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An issue was encountered while getting the productAttributes by ProductId : {request.ProductId}.");
                return new List<ProductAttribute>();
            }
        }
    }
}
