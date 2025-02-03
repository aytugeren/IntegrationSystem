using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantPictureDTOs;

namespace ProductMicroservice.Business.ProductVariantPictureServiceFolder
{
    public interface IProductVariantPictureService
    {
        Task<bool> AddProductVariantPicture(ProductVariantPictureDTO productVariantPictureDTO);

        Task<int> DeleteProductVariantPicture(Guid productVariantId, Guid pictureId);

        Task<int> BulkAddProductVariantPictures(List<AddProductVariantPictureDTO> productVariantPictures);

        Task<int> BulkDeleteProductVariantPictures(List<AddProductVariantPictureDTO> productVariantPictures);
    }
}
