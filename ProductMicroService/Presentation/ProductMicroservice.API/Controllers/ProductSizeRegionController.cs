using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.ProductSizeRegionServiceFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeRegionDTos;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeRegionController : ControllerBase
    {
        private readonly IProductSizeRegionService _productSizeRegionService;

        public ProductSizeRegionController(IProductSizeRegionService productSizeRegionService)
        {
            _productSizeRegionService = productSizeRegionService;
        }

        [HttpPost("AddProductSizeRegion")]
        public async Task<bool> AddProductSizeRegion(AddProductSizeRegionDTO model)
        {
            var result = await _productSizeRegionService.AddProductSizeRegion(model);
            return result;
        }

        [HttpGet("GetAllProductSizeRegions")]
        public async Task<List<ProductVariantSizeRegionDTO>> GetAllProductSizeRegions()
        {
            var result = await _productSizeRegionService.GetAllProductSizeRegions();
            return result;
        }

        [HttpDelete("DeleteProductSizeRegion")]
        public async Task<bool> DeleteProductSizeRegion(Guid id)
        {
            var result = await _productSizeRegionService.DeleteProductSizeRegion(id);
            return result;
        }

        [HttpPost("BulkAddProductSizeRegions")]
        public async Task<bool> BulkAddProductSizeRegions(List<AddProductSizeRegionDTO> productSizeRegions)
        {
            var result = await _productSizeRegionService.BulkAddProductSizeRegion(productSizeRegions);
            return result;
        }

        [HttpDelete("BulkDeleteProductSizeRegions")]
        public async Task<bool> BulkDeleteProductSizeRegions(List<Guid> ids)
        {
            var result = await _productSizeRegionService.BulkDeleteProductSizeRegion(ids);
            return result;
        }

        [HttpPut("UpdateProductSizeRegion")]
        public async Task<bool> UpdateProductSizeRegion(UpdateProductSizeRegionDTO productSizeRegionDTO)
        {
            var result = await _productSizeRegionService.UpdateProductSizeRegion(productSizeRegionDTO);
            return result;
        }
    }
}
