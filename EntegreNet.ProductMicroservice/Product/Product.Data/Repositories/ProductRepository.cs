using Microsoft.EntityFrameworkCore;
using Product.Application.Interfaces;
using Product.Data.ContextFolder;
using Product.Domain.Entities;

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
