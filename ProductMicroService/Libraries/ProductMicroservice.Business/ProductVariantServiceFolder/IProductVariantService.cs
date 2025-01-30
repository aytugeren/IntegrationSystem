using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantDTOs;

namespace ProductMicroservice.Business.ProductVariantServiceFolder
{
	public interface IProductVariantService
	{
		Task<List<ProductVariantDTO>> GetAllProductVariants();

		Task<ProductVariantDTO> GetProductVariantById(Guid id);

		Task<bool> AddProductVariant(AddProductVariantDTO productDTO);

		Task<bool> DeleteProductVariant(Guid id);

		Task<bool> UpdateProductVariant(UpdateProductVariantDTO productDTO);

		Task<bool> BulkAddProductVariants(List<AddProductVariantDTO> products);

		Task<bool> BulkDeleteProductVariants(List<Guid> ids);
	}
}
