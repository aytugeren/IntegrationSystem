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

        public GetAllAttributesHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<Models.Attribute>> Handle(GetAllAttributesQuery request, CancellationToken cancellationToken)
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
    }
}
