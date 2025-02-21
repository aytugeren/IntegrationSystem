using AttributeService.CQRS.Commands;
using AttributeService.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class DeleteProductAttributeHandler : IRequestHandler<DeleteProductAttributeCommand, bool>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly ILogger<DeleteProductAttributeHandler> _logger;

        public DeleteProductAttributeHandler(AttributeDbContext context, IDistributedCache cache, ILogger<DeleteProductAttributeHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteProductAttributeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var mapping = await _context.ProductAttributes.Where(x => x.ProductId == request.ProductId && x.AttributeId == request.AttributeId).ToListAsync();

                if (!mapping.Any()) return false;

                foreach (var item in mapping)
                {
                    _context.ProductAttributes.Remove(item);
                    await _context.SaveChangesAsync();
                }

                _cache.Remove("productAttributes");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An issue was encountered while deleting the productAttribute.");
                return false;
            }
        }
    }
}
