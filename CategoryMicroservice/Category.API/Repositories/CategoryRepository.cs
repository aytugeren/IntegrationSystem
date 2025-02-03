namespace Category.API.Repositories
{
    using Category.API.Data;
    using Category.API.Entities;
    using MongoDB.Driver;

    public class CategoryRepository : ICategoryRepositories
    {
        private readonly ICategoryContext _context;

        public CategoryRepository(ICategoryContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategory(Category category)
        {
            await _context.Categories.InsertOneAsync(category);
            return true;
        }

        public async Task<bool> DeleteCategory(string id)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(c => c.Id, id);
            DeleteResult deleteResult = await _context.Categories.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.Find(prop => true).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByName(string name)
        {
            // Creating Filter 
            //Eq like operation = ElemMatch not it
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(p => p.Name, name);

            return await _context.Categories.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateCategory(Entities.Category category)
        {
            var updateResult = await _context.Categories.ReplaceOneAsync(filter: g => g.Id == category.Id, replacement: category);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
