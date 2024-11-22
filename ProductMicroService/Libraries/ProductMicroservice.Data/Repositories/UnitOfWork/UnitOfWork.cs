using ProductMicroservice.Entities.Entities;

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
        public IRepository<ProductSizeRegion> ProductSizeRegions => new Repository<ProductSizeRegion>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
