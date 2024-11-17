using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var product = await _unitOfWork.Products.Query(x => x.Id == productDTO.Id).FirstOrDefaultAsync();

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
    }
}
