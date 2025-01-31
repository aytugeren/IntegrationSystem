using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeRegionDTos;

namespace ProductMicroservice.Business.ProductSizeRegionServiceFolder
{
    public interface IProductSizeRegionService
    {
        Task<List<ProductVariantSizeRegionDTO>> GetAllProductSizeRegions();

        Task<ProductVariantSizeRegionDTO> GetProductSizeRegionBySizeId(Guid id);

        Task<bool> AddProductSizeRegion(AddProductSizeRegionDTO productSizeRegionDTO);

        Task<bool> DeleteProductSizeRegion(Guid id);

        Task<bool> UpdateProductSizeRegion(UpdateProductSizeRegionDTO productSizeRegionDTO);

        Task<bool> BulkAddProductSizeRegion(List<AddProductSizeRegionDTO> productSizeRegions);

        Task<bool> BulkDeleteProductSizeRegion(List<Guid> ids);
    }
}
