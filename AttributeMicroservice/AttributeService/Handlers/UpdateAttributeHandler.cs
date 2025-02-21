using AttributeService.CQRS.Commands;
using AttributeService.Data;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class UpdateAttributeHandler : IRequestHandler<UpdateAttributeCommand, bool>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<UpdateAttributeHandler> _logger;

        public UpdateAttributeHandler(AttributeDbContext context, IDistributedCache cache, ILogger<UpdateAttributeHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var attribute = await _context.Attributes.FindAsync(request.Id);

                if (attribute == null) return false;

                attribute.Name = request.Name;

                _context.Attributes.Update(attribute);
                await _context.SaveChangesAsync();


                await _cache.RemoveAsync("all_attributes");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An issue was encountered while updating the attribute.");
                return false;
            }
        }
    }
}
