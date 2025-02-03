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
        Task<bool> DeleteWithModelAsync(T entity);
        Task<bool> BulkDeleteAsync(List<T> ids);
        Task<List<T>> Query(Expression<Func<T, bool>> predicate);
    }
}
