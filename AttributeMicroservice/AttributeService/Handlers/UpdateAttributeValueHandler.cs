using AttributeService.CQRS.Commands;
using AttributeService.Data;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class UpdateAttributeValueHandler : IRequestHandler<UpdateAttributeValueCommand, bool>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<UpdateAttributeValueHandler> _logger;

        public UpdateAttributeValueHandler(AttributeDbContext context, IDistributedCache cache, ILogger<UpdateAttributeValueHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateAttributeValueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var attributeValue = await _context.AttributeValues.FindAsync(request.Id);
                if (attributeValue == null) return false;

                attributeValue.Value = request.Value;
                await _context.SaveChangesAsync(cancellationToken);

                await _cache.RemoveAsync("attributeValues");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An issue was encountered while updating the attributeValue.");
                return false;
            }
        }
    }
}
