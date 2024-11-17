using ProductMicroservice.Business.DTOFolder;
using ProductMicroservice.Business.DTOFolder.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Business.ProductServiceFolder
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();

        Task<ProductDTO> GetProductById(Guid id);

        Task<bool> AddProduct(AddProductDTO productDTO);

        Task<bool> DeleteProduct(Guid id);

        Task<bool> UpdateProduct(AddProductDTO productDTO);
    }
}
