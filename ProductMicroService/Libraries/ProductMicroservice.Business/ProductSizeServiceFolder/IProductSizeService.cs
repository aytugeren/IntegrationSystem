using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs;

namespace ProductMicroservice.Business.ProductSizeServiceFolder
{
    public interface IProductSizeService
    {
        Task<List<ProductSizeDTO>> GetAllProductSizes();

        Task<ProductSizeDTO> GetProductSizeById(Guid id);

        Task<bool> AddProductSize(AddProductSizeDTO productSizeDTO);

        Task<bool> DeleteProductSize(Guid id);

        Task<bool> UpdateProductSize(UpdateProductSizeDTO productSizeDTO);

        Task<bool> BulkAddProductSizes(List<AddProductSizeDTO> productSizes);

        Task<bool> BulkDeleteProductSizes(List<Guid> ids);
    }
}
