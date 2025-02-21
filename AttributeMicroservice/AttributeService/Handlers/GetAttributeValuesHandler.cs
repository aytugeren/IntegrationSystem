using AttributeService.CQRS.Queries;
using AttributeService.Data;
using AttributeService.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AttributeService.Handlers
{
    public class GetAttributeValuesHandler : IRequestHandler<GetAttributeValuesQuery, List<AttributeValue>>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<GetAttributeValuesHandler> _logger;

        public GetAttributeValuesHandler(AttributeDbContext context, IDistributedCache cache, ILogger<GetAttributeValuesHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<List<AttributeValue>> Handle(GetAttributeValuesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string cacheKey = "attributeValues";
                var cachedAttributes = await _cache.GetStringAsync(cacheKey);

                if (!string.IsNullOrEmpty(cachedAttributes))
                {
                    return JsonSerializer.Deserialize<List<AttributeValue>>(cachedAttributes);
                }

                var attributeValues = await _context.AttributeValues.
                    Include(pa => pa.Attribute).
                    ToListAsync(cancellationToken);

                if (attributeValues.Any())
                {
                    var serializedAttributeValues = JsonSerializer.Serialize(attributeValues);
                    await _cache.SetStringAsync(cacheKey, serializedAttributeValues, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)  // 30 dakika cache
                    });
                }

                return attributeValues;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An issue was encountered while getting the attributeValues by AttributeId : {request.AttributeId}.");
                return new List<AttributeValue>();
            }
        }
    }
}
