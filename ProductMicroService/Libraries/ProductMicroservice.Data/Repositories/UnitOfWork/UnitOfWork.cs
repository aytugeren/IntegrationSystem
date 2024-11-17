using ProductMicroservice.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _context;

        public UnitOfWork(ProductContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products => new Repository<Product>(_context);
        public IRepository<Picture> Pictures => new Repository<Picture>(_context);
        public IRepository<ProductVariantPicture> ProductVariantPictures => new Repository<ProductVariantPicture>(_context);
        public IRepository<ProductVariant> ProductVariants => new Repository<ProductVariant>(_context);
        public IRepository<ProductSize> ProductSizes => new Repository<ProductSize>(_context);

        public IRepository<ProductSizeRegion> ProductSizeRegion => new Repository<ProductSizeRegion>(_context);

        // Diğer entity'ler için repository implementasyonları

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
