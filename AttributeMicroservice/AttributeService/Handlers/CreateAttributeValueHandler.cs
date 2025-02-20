using AttributeService.CQRS.Commands;
using AttributeService.Data;
using AttributeService.Models;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class CreateAttributeValueHandler : IRequestHandler<CreateAttributeValueCommand, Guid>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;

        public CreateAttributeValueHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = new AttributeValue
            {
                AttributeId = request.AttributeId,
                Value = request.Value
            };

            _context.AttributeValues.Add(attributeValue);
            await _context.SaveChangesAsync();

            await _cache.RemoveAsync("attributeValues");

            return attributeValue.Id;
        }
    }
}
