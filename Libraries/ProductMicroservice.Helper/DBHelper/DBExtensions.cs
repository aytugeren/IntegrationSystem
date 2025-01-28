using Microsoft.EntityFrameworkCore;

namespace ProductMicroservice.Helper.DBHelper
{
    public static class DBExtensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query, DbContext context) where T : class
        {
            var entityType = context.Model.FindEntityType(typeof(T));

            if (entityType == null)
                return query;

            var navigations = entityType.GetNavigations(); // Tüm navigation özelliklerini al

            foreach (var navigation in navigations)
            {
                query = query.Include(navigation.Name); // Navigation property adıyla Include yap
            }

            return query;
        }
    }
}
