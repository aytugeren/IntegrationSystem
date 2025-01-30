using AutoMapper;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductSizeDTOs;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.ProductSizeServiceFolder
{
    public class ProductSizeService : IProductSizeService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductSizeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddProductSize(AddProductSizeDTO productSizeDTO)
        {
            var productSizeTemp = _mapper.Map<ProductSizeDTO>(productSizeDTO);
            var productSizeEntity = _mapper.Map<ProductSize>(productSizeTemp);

            var result = await _unitOfWork.ProductSizes.AddAsync(productSizeEntity);
            return result;
        }

        public async Task<bool> BulkAddProductSizes(List<AddProductSizeDTO> productSizes)
        {
            var productSizesTemp = _mapper.Map<List<ProductSizeDTO>>(productSizes);
            var productSizesEntity = _mapper.Map<List<ProductSize>>(productSizesTemp);

            var result = await _unitOfWork.ProductSizes.BulkAddAsync(productSizesEntity);

            return result;
        }

        public async Task<bool> BulkDeleteProductSizes(List<Guid> ids)
        {
            var productSizes = await _unitOfWork.ProductSizes.Query(x => x.Id != null && ids.Contains(x.Id.Value));
            var deleteResult = await _unitOfWork.ProductSizes.BulkDeleteAsync(productSizes);
            return deleteResult;
        }

        public async Task<bool> DeleteProductSize(Guid id)
        {
            var productSize = await _unitOfWork.ProductSizes.GetByIdAsync(id);

            if (productSize != null)
            {
                var result = await _unitOfWork.ProductSizes.DeleteAsync(id);
                return result;
            }

            return false;
        }

        public async Task<List<ProductSizeDTO>> GetAllProductSizes()
        {
            var productVariants = await _unitOfWork.ProductSizes.GetAllAsync();
            return _mapper.Map<List<ProductSizeDTO>>(productVariants);
        }

        public async Task<ProductSizeDTO> GetProductSizeById(Guid id)
        {
            var productSize = await _unitOfWork.ProductSizes.GetByIdAsync(id);
            return _mapper.Map<ProductSizeDTO>(productSize);
        }

        public async Task<bool> UpdateProductSize(UpdateProductSizeDTO productSizeDTO)
        {
            var size = await _unitOfWork.ProductSizes.GetByIdAsync(productSizeDTO.Id);

            if (size != null)
            {
                size.SizeCode = productSizeDTO.SizeCode;
                size.Barcode = productSizeDTO.Barcode;

                var result = await _unitOfWork.ProductSizes.UpdateAsync(size);
                return result;
            }

            return false;
        }
    }
}
