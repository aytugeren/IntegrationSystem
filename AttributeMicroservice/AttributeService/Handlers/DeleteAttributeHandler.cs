using AttributeService.CQRS.Commands;
using AttributeService.Data;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class DeleteAttributeHandler : IRequestHandler<DeleteAttributeCommand, bool>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;

        public DeleteAttributeHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<bool> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = await _context.Attributes.FindAsync(request.Id, cancellationToken);

            if (attribute == null) return false;

            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();

            _cache.Remove("all_attributes");

            return true;
        }
    }
}
