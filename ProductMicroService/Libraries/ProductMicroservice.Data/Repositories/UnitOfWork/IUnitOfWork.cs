using ProductMicroservice.Entities.Entities;

namespace ProductMicroservice.Data.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Picture> Pictures { get; }
        IRepository<ProductVariantPicture> ProductVariantPictures { get; }
        IRepository<ProductVariant> ProductVariants { get; }
        IRepository<ProductSize> ProductSizes { get; }
        IRepository<ProductSizeRegion> ProductSizeRegions { get; }
    }
}
