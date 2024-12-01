using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Business.ProductServiceFolder;

namespace ProductMicroservice.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpPost("AddProduct")]
		public async Task<bool> AddProduct(AddProductDTO model)
		{
			var result = await _productService.AddProduct(model);
			return result;
		}

		[HttpGet("GetAllProduct")]
		public async Task<List<ProductDTO>> GetAllProducts()
		{
			var result = await _productService.GetAllProducts();
			return result;
		}

		[HttpDelete("DeleteProduct")]
		public async Task<bool> DeleteProduct(Guid id)
		{
			var result = await _productService.DeleteProduct(id);
			return result;
		}

		[HttpPost("BulkAddProducts")]
		public async Task<bool> BulkAddProducts(List<AddProductDTO> products)
		{
			var result = await _productService.BulkAddProducts(products);
			return result;
		}

		[HttpDelete("BulkDeleteProducts")]
		public async Task<bool> BulkDeleteProducts(List<Guid> ids)
		{
			var result = await _productService.BulkDeleteProducts(ids);
			return result;
		}
	}
}
