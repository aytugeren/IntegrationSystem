namespace Category.API.Repositories
{
    using Category.API.Entities;

    public interface ICategoryRepositories
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<IEnumerable<Category>> GetCategoriesByName(string name);

        Task<bool> AddCategory(Category category);

        Task<bool> UpdateCategory(Category category);

        Task<bool> DeleteCategory(string id);
    }
}
