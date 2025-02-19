using AttributeService.CQRS.Commands;
using AttributeService.Data;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace AttributeService.Handlers
{
    public class CreateAttributeHandler : IRequestHandler<CreateAttributeCommand, Guid>
    {
        private readonly AttributeDbContext _context;
        private readonly IDistributedCache _cache;

        public CreateAttributeHandler(AttributeDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<Guid> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            var attribute = new Models.Attribute
            {
                Name = request.Name
            };

            _context.Attributes.Add(attribute);
            await _context.SaveChangesAsync();

            await _cache.RemoveAsync("all_attributes", cancellationToken);

            return attribute.Id;
        }

    }
}
