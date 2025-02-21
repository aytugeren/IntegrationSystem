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
        private readonly ILogger<DeleteAttributeValueHandler> _logger;

        public DeleteAttributeValueHandler(AttributeDbContext context, IDistributedCache cache, ILogger<DeleteAttributeValueHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteAttributeValueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var attributeValue = await _context.AttributeValues.FindAsync(request.Id);

                if (attributeValue == null) return false;

                _context.AttributeValues.Remove(attributeValue);
                await _context.SaveChangesAsync();

                await _cache.RemoveAsync("attributeValues");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An issue was encountered while deleting the attributeValue.");
                return false;
            }
        }
    }
}
