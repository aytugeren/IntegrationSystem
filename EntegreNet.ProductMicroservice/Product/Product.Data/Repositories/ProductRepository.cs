using Microsoft.EntityFrameworkCore;
using Product.Application.Features.Commands.CreateProduct;
using Product.Application.Interfaces;
using Product.Data.ContextFolder;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Data.Repositories
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            var productList = await _context.Products.ToListAsync();

            return productList;
        }
    }
}
