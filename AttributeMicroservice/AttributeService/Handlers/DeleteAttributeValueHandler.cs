using AttributeService.CQRS.Commands;
using AttributeService.Data;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class DeleteAttributeValueHandler : IRequestHandler<DeleteAttributeValueCommand, bool>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;

        public DeleteAttributeValueHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Handle(DeleteAttributeValueCommand request, CancellationToken cancellationToken)
        {
            var attributeValue = await _context.AttributeValues.FindAsync(request.Id);

            if (attributeValue == null) return false;

            _context.AttributeValues.Remove(attributeValue);
            await _context.SaveChangesAsync();

            await _cache.RemoveAsync("attributeValues");

            return true;
        }
    }
}
