using AutoMapper;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeRegionDTos;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.ProductSizeRegionServiceFolder
{
    public class ProductSizeRegionService : IProductSizeRegionService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductSizeRegionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddProductSizeRegion(AddProductSizeRegionDTO productSizeRegionDTO)
        {
            var productSizeRegionModel = _mapper.Map<ProductVariantSizeRegionDTO>(productSizeRegionDTO);
            var productSizeRegionEntity = _mapper.Map<ProductSizeRegion>(productSizeRegionModel);

            var result = await _unitOfWork.ProductSizeRegions.AddAsync(productSizeRegionEntity);

            return result;
        }

        public async Task<bool> BulkAddProductSizeRegion(List<AddProductSizeRegionDTO> productSizeRegions)
        {
            var productSizeRegionModel = _mapper.Map<List<ProductVariantSizeRegionDTO>>(productSizeRegions);
            var productSizeRegionEntities = _mapper.Map<List<ProductSizeRegion>>(productSizeRegionModel);

            var result = await _unitOfWork.ProductSizeRegions.BulkAddAsync(productSizeRegionEntities);
            return result;
        }

        public async Task<bool> BulkDeleteProductSizeRegion(List<Guid> ids)
        {
            var productSizeRegions = await _unitOfWork.ProductSizeRegions.Query(x => x.Id != null && ids.Contains(x.Id.Value));
            var deleteResult = await _unitOfWork.ProductSizeRegions.BulkDeleteAsync(productSizeRegions);
            return deleteResult;
        }

        public async Task<bool> DeleteProductSizeRegion(Guid id)
        {
            var productSizeRegion = await _unitOfWork.ProductSizeRegions.GetByIdAsync(id);

            if (productSizeRegion != null)
            {
                var result = await _unitOfWork.ProductSizeRegions.DeleteAsync(id);

                return result;
            }

            return false;
        }

        public async Task<List<ProductVariantSizeRegionDTO>> GetAllProductSizeRegions()
        {
            var productSizeRegions = await _unitOfWork.ProductSizeRegions.GetAllAsync();
            return _mapper.Map<List<ProductVariantSizeRegionDTO>>(productSizeRegions);
        }

        public async Task<ProductVariantSizeRegionDTO> GetProductSizeRegionBySizeId(Guid id)
        {
            var productSizeRegion = await _unitOfWork.ProductSizeRegions.GetByIdAsync(id);

            return _mapper.Map<ProductVariantSizeRegionDTO>(productSizeRegion);
        }

        public async Task<bool> UpdateProductSizeRegion(UpdateProductSizeRegionDTO productSizeRegionDTO)
        {
            var productSizeRegion = await _unitOfWork.ProductSizeRegions.GetByIdAsync(productSizeRegionDTO.Id);

            if (productSizeRegion != null )
            {
                productSizeRegion.Quantity = productSizeRegionDTO.Quantity;
                productSizeRegion.LogMessage = $"{DateTime.Now} tarihinde verileri güncellendi!";

                var result = await _unitOfWork.ProductSizeRegions.UpdateAsync(productSizeRegion);
                return result;
            }

            return false;
        }
    }
}
