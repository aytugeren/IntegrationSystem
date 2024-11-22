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

		[HttpPost(Name = "AddProduct")]
		public async Task<bool> AddProduct(AddProductDTO model)
		{
			var result = await _productService.AddProduct(model);
			return result;
		}

		[HttpGet(Name = "GetAllProduct")]
		public async Task<List<ProductDTO>> GetAllProducts()
		{
			var result = await _productService.GetAllProducts();
			return result;
		}
	}
}
