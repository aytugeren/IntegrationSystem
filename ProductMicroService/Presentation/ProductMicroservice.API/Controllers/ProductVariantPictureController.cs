using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantPictureDTOs;
using ProductMicroservice.Business.ProductVariantPictureServiceFolder;

namespace ProductMicroservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantPictureController : ControllerBase
    {
        private readonly IProductVariantPictureService _productVariantPictureService;

        public ProductVariantPictureController(IProductVariantPictureService productVariantPictureService)
        {
            _productVariantPictureService = productVariantPictureService;
        }

        [HttpPost("AddProductVariantPicture")]
        public async Task<bool> AddProductVariantPicture(Guid productVariantId, Guid pictureId)
        {
            var productVariantPictureDTO = new ProductVariantPictureDTO () { PictureId = pictureId, ProductVariantId = productVariantId };
            var result = await _productVariantPictureService.AddProductVariantPicture(productVariantPictureDTO);
            return result;
        }

        [HttpDelete("DeleteProductVariantPicture")]
        public async Task<int> DeleteProductVariantPicture(Guid productVariantId, Guid pictureId)
        {
            var result = await _productVariantPictureService.DeleteProductVariantPicture(productVariantId, pictureId);
            return result;
        }

        [HttpPost("BulkAddProductVariantPictures")]
        public async Task<int> BulkAddProductVariantPicture(List<AddProductVariantPictureDTO> productVariantPictureDTOs)
        {
            var result = await _productVariantPictureService.BulkAddProductVariantPictures(productVariantPictureDTOs);
            return result;
        }

        [HttpDelete("BulkDeleteProductVariantPictures")]
        public async Task<int> BulkDeleteProductVariantPictures(List<AddProductVariantPictureDTO> productVariantPictureDTOs)
        {
            var result = await _productVariantPictureService.BulkDeleteProductVariantPictures(productVariantPictureDTOs);
            return result;
        }
    }
}
