using System.Linq.Expressions;

namespace ProductMicroservice.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> BulkAddAsync(List<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> BulkDeleteAsync(List<T> ids);
        Task<IEnumerable<T>> GetBulkDataByIdAsync(List<Guid> id);
        Task<List<T>> Query(Expression<Func<T, bool>> predicate);
    }
}
