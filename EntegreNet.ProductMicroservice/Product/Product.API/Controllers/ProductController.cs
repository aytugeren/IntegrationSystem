using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Features.Commands.CreateProduct;
using Product.Application.Features.Queries.GetAllProducts;
using Product.Application.Model;
using System.Net;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var productList = await _mediator.Send(query);
            return Ok(productList);
        }
    }
}
