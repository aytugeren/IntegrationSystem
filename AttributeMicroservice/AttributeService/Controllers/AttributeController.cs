using AttributeService.CQRS.Commands;
using AttributeService.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AttributeService.Controllers
{
    [Route("api/attributes")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AttributeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAttributes()
        {
            var attributes = await _mediator.Send(new GetAllAttributesQuery());
            return Ok(attributes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttribute([FromBody] CreateAttributeCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id }, command);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductAttributes()
        {
            var productAttributes = await _mediator.Send(new GetProductAttributeQuery());
            return Ok(productAttributes);
        }
    }
}
