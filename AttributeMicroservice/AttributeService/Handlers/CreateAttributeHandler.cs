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
        private readonly ILogger<CreateAttributeHandler> _logger;

        public CreateAttributeHandler(AttributeDbContext context, IDistributedCache cache, ILogger<CreateAttributeHandler> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public async Task<Guid> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An issue was encountered while creating the attribute.");
                return Guid.Empty;
            }
        }

    }
}
