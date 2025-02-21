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
        private readonly ILogger<AttributeController> _logger;

        public AttributeController(IMediator mediator, ILogger<AttributeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetAllAttributes", Name ="GetAllAttributes")]
        public async Task<IActionResult> GetAllAttributes()
        {
            var attributes = await _mediator.Send(new GetAllAttributesQuery());
            return Ok(attributes);
        }

        [HttpPost("CreateAttribute")]
        public async Task<IActionResult> CreateAttribute([FromBody] CreateAttributeCommand command)
        {
            var id = await _mediator.Send(command);
            
            _logger.LogInformation("New Attribute is created!");
            return CreatedAtRoute("GetAllAttributes", null);

        }

        [HttpPut("UpdateAttribute")]
        public async Task<IActionResult> UpdateAttribute([FromBody] UpdateAttributeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteAttribute/{id}")]
        public async Task<IActionResult> DeleteAttribute(Guid id)
        {
            var result = await _mediator.Send(new DeleteAttributeCommand { Id = id });
            return Ok(result);
        }

        [HttpGet("GetAllProductAttributes/{productId}")]
        public async Task<IActionResult> GetAllProductAttributes(Guid productId)
        {
            var productAttributes = await _mediator.Send(new GetProductAttributeQuery { ProductId = productId });
            return Ok(productAttributes);
        }

        [HttpPost("AddProductAttribute")]
        public async Task<IActionResult> AddProductAttribute([FromBody] AddProductAttributeComand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAllProductAttributes), new { productId = command.ProductId }, command);
        }

        [HttpDelete("DeleteProductAttribute")]
        public async Task<IActionResult> DeleteProductAttribute([FromBody] DeleteAttributeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAttributeValues/{attributeId}", Name ="GetAttributeValues")]
        public async Task<IActionResult> GetAttributeValues(Guid attributeId)
        {
            var values = await _mediator.Send(new GetAttributeValuesQuery { AttributeId = attributeId });
            return Ok(values);
        }

        [HttpPost("CreateAttributeValues", Name = "CreateAttributeValues")]
        public async Task<IActionResult> CreateAttributeValues([FromBody] CreateAttributeValueCommand command)
        {
            var id = await _mediator.Send(command);
            return Created("GetAttributeValues/{attributeId}", new { attributeId = id });
        }

        [HttpDelete("DeleteAttributeValue/{id}")]
        public async Task<IActionResult> DeleteAttributeValue(Guid id)
        {
            var result = await _mediator.Send(new DeleteAttributeValueCommand { Id = id });
            return Ok(result);
        }
    }
}
