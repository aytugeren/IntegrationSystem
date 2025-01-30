using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.ProductSizeServiceFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeService _productSizeService;

        public ProductSizeController(IProductSizeService productSizeService)
        {
            _productSizeService = productSizeService;
        }

        [HttpPost("AddProductSize")]
        public async Task<bool> AddProductSize(AddProductSizeDTO model)
        {
            var result = await _productSizeService.AddProductSize(model);
            return result;
        }

        [HttpGet("GetAllProductSizes")]
        public async Task<List<ProductSizeDTO>> GetAllProductSizes()
        {
            var result = await _productSizeService.GetAllProductSizes();
            return result;
        }

        [HttpDelete("DeleteProductSize")]
        public async Task<bool> DeleteProductSize(Guid id)
        {
            var result = await _productSizeService.DeleteProductSize(id);
            return result;
        }

        [HttpPost("BulkAddProductSizes")]
        public async Task<bool> BulkAddProductSizes(List<AddProductSizeDTO> products)
        {
            var result = await _productSizeService.BulkAddProductSizes(products);
            return result;
        }

        [HttpDelete("BulkDeleteProductSizes")]
        public async Task<bool> BulkDeleteProductSizes(List<Guid> ids)
        {
            var result = await _productSizeService.BulkDeleteProductSizes(ids);
            return result;
        }

        [HttpPut("UpdateProductSize")]
        public async Task<bool> UpdateProductSize(UpdateProductSizeDTO picture)
        {
            var result = await _productSizeService.UpdateProductSize(picture);
            return result;
        }
    }
}
