using MongoDB.Driver;

namespace Category.API.Data
{
    public class CategoryContext : ICategoryContext
    {
        public CategoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Categories = database.GetCollection<Entities.Category>(configuration.GetValue<string>("DatabaseSettings.CollectionName"));
        }

        public IMongoCollection<Entities.Category> Categories { get; }
    }
}
