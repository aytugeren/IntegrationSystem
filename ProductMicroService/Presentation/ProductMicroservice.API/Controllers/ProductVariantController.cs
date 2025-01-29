using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantDTOs;
using ProductMicroservice.Business.ProductVariantServiceFolder;

namespace ProductMicroservice.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductVariantController : ControllerBase
	{
		private readonly IProductVariantService _productVariantService;

		public ProductVariantController(IProductVariantService productVariantService)
		{
			_productVariantService = productVariantService;
		}

		[HttpPost("AddProductVariant")]
		public async Task<bool> AddProductVariant(AddProductVariantDTO productVariantDTO)
		{
			var result = await _productVariantService.AddProductVariant(productVariantDTO);
			return result;
		}

		[HttpGet("GetProductVariantById")]
		public async Task<ProductVariantDTO> GetProductVariantById(Guid id)
		{
			var result = await _productVariantService.GetProductVariantById(id);
			return result;
		}

		[HttpPut("UpdateProductVariant")]
		public async Task<bool> UpdateProductVariant(UpdateProductVariantDTO prouductVariant)
		{
			var result = await _productVariantService.UpdateProductVariant(prouductVariant);
			return result;
		}

		[HttpGet("GetAllProductVariants")]
		public async Task<List<ProductVariantDTO>> GetAllProductVariants()
		{
			var result = await _productVariantService.GetAllProductVariants();
			return result;
		}

		[HttpDelete("DeleteProductVariant")]
		public async Task<bool> DeleteProductVariant(Guid id)
		{
			var result = await _productVariantService.DeleteProductVariant(id);
			return result;
		}

		[HttpPost("BulkAddProducts")]
		public async Task<bool> BulkAddProducts(List<AddProductVariantDTO> products)
		{
			var result = await _productVariantService.BulkAddProductVariants(products);
			return result;
		}

		[HttpDelete("BulkDeleteProducts")]
		public async Task<bool> BulkDeleteProducts(List<Guid> ids)
		{
			var result = await _productVariantService.BulkDeleteProductVariants(ids);
			return result;
		}


	}
}
