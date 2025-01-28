using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Business.ProductServiceFolder
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddProduct(AddProductDTO productDTO)
        {
            var productModel = _mapper.Map<ProductDTO>(productDTO);
            var product = _mapper.Map<Product>(productModel);

            var result = await _unitOfWork.Products.AddAsync(product);

            return result;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product != null)
            {
                var result = await _unitOfWork.Products.DeleteAsync(id);

                return result;
            }

            return false;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> UpdateProduct(UpdateProductDTO productDTO)
        {
            var allProducts = await _unitOfWork.Products.Query(x => x.Id == productDTO.Id);
            var product = allProducts.FirstOrDefault();

            if (product != null)
            {
                product.ProductName = productDTO.ProductName;
                product.ProductMainCode = productDTO.ProductMainCode;
                product.BrandId = productDTO.BrandId;
                product.VatRate = productDTO.VatRate;

                var result = await _unitOfWork.Products.UpdateAsync(product);
                return result;
            }

            return false;
        }

        public async Task<bool> BulkAddProducts(List<AddProductDTO> products)
        {
            var productModel = _mapper.Map<List<ProductDTO>>(products);
            var product = _mapper.Map<List<Product>>(productModel);

            var result = await _unitOfWork.Products.BulkAddAsync(product);
            return result;
        }

        public async Task<bool> BulkDeleteProducts(List<Guid> ids)
        {
            var products = await _unitOfWork.Products.Query(x => x.Id != null && ids.Contains(x.Id.Value));
            var deleteResult = await _unitOfWork.Products.BulkDeleteAsync(products);
            return deleteResult;
        }
    }
}
