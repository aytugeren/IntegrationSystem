using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Helper.DBHelper;
using System.Linq.Expressions;

namespace ProductMicroservice.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ProductContext _context;
        DbSet<T> _dbSet;

        public Repository(ProductContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

		public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = _dbSet.IncludeAll(_context);
            return await query.ToListAsync();
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<T>> Query(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<bool> BulkAddAsync(List<T> entities)
        {
            try
            {
				await _dbSet.AddRangeAsync(entities);
				await _context.SaveChangesAsync();

                return true;
			}
            catch (Exception)
            {
                return false;
            }
		}

        public async Task<bool> BulkDeleteAsync(List<T> entities)
        {
            try
            {
                if (entities != null)
                {
                    _dbSet.RemoveRange(entities);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
