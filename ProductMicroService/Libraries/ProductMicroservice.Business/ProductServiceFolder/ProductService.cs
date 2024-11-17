using AutoMapper;
using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using ProductMicroservice.Data.Repositories.UnitOfWork;
using ProductMicroservice.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Business.ProductServiceFolder
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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

        public Task<bool> DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDTO>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(AddProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
