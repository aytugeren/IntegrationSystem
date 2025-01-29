using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.PictureDTOs;

namespace ProductMicroservice.Business.ProductServiceFolder
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();

        Task<ProductDTO> GetProductById(Guid id);

        Task<bool> AddProduct(AddProductDTO productDTO);

        Task<bool> DeleteProduct(Guid id);

        Task<bool> UpdateProduct(UpdateProductDTO productDTO);

        Task<bool> BulkAddProducts(List<AddProductDTO> products);

        Task<bool> BulkDeleteProducts(List<Guid> ids);
	}
}
