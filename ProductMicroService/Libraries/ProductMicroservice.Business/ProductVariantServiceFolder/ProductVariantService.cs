using AutoMapper;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs.ProductVariantDTOs;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.ProductVariantServiceFolder
{
	public class ProductVariantService : IProductVariantService
	{
		private readonly IUnitOfWork _unitOfWork;
		private IMapper _mapper;

		public ProductVariantService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<bool> AddProductVariant(AddProductVariantDTO productDTO)
		{
			var productVariant = _mapper.Map<ProductVariantDTO>(productDTO);
			var entity = _mapper.Map<ProductVariant>(productVariant);

			var result = await _unitOfWork.ProductVariants.AddAsync(entity);

			return result;
		}

		public async Task<bool> BulkAddProductVariants(List<AddProductVariantDTO> products)
		{
			var productVariants = _mapper.Map<List<ProductVariantDTO>>(products);
			var entities = _mapper.Map<List<ProductVariant>>(productVariants);

			var result = await _unitOfWork.ProductVariants.BulkAddAsync(entities);

			return result;
		}

		public async Task<bool> BulkDeleteProductVariants(List<Guid> ids)
		{
			var productVariants = await _unitOfWork.ProductVariants.Query(x => x.Id != null && ids.Contains(x.Id.Value));
			var deleteResult = await _unitOfWork.ProductVariants.BulkDeleteAsync(productVariants);
			return deleteResult;
		}

		public async Task<bool> DeleteProductVariant(Guid id)
		{
			var productVariant = await _unitOfWork.ProductVariants.GetByIdAsync(id);

			if (productVariant != null)
			{
				var result = await _unitOfWork.ProductVariants.DeleteAsync(id);

				return result;
			}

			return false;
		}

		public async Task<List<ProductVariantDTO>> GetAllProductVariants()
		{
			var productVariants = await _unitOfWork.ProductVariants.GetAllAsync();

			return _mapper.Map<List<ProductVariantDTO>>(productVariants);
		}

		public async Task<ProductVariantDTO> GetProductVariantById(Guid id)
		{
			var productVariant = await _unitOfWork.ProductVariants.GetByIdAsync(id);

			return _mapper.Map<ProductVariantDTO>(productVariant);
		}

		public async Task<bool> UpdateProductVariant(UpdateProductVariantDTO productDTO)
		{
			var allProducts = await _unitOfWork.ProductVariants.Query(x => x.Id == productDTO.Id);
			var product = allProducts.FirstOrDefault();

			if (product != null)
			{
				product.ProductVariantName = productDTO.ProductVariantName;
				product.ProductVariantCode = productDTO.ProductVariantCode;
				product.CargoId = productDTO.CargoId;
				product.DeliveryDuration = productDTO.DeliveryDuration;
				product.Description = productDTO.Description;

				var result = await _unitOfWork.ProductVariants.UpdateAsync(product);
				return result;
			}

			return false;
		}
	}
}
