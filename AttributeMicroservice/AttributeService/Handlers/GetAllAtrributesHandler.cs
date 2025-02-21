using AttributeService.CQRS.Queries;
using AttributeService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace AttributeService.Handlers
{
    public class GetAllAttributesHandler : IRequestHandler<GetAllAttributesQuery, List<Models.Attribute>>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<GetAllAttributesHandler> _logger;

        public GetAllAttributesHandler(AttributeDbContext context, IDistributedCache cache, ILogger<GetAllAttributesHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<List<Models.Attribute>> Handle(GetAllAttributesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                string cacheKey = "all_attributes";
                var cachedAttributes = await _cache.GetStringAsync(cacheKey);

                if (!string.IsNullOrEmpty(cachedAttributes))
                {
                    return JsonSerializer.Deserialize<List<Models.Attribute>>(cachedAttributes);
                }

                var attributes = await _context.Attributes.ToListAsync(cancellationToken);

                if (attributes.Any())
                {
                    var serializedAttributes = JsonSerializer.Serialize(attributes);
                    await _cache.SetStringAsync(cacheKey, serializedAttributes, new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)  // 30 dakika cache
                    });
                }

                return attributes;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An issue was encountered while getting the all attributes.");
                return new List<Models.Attribute>();
            }
        }
    }
}
