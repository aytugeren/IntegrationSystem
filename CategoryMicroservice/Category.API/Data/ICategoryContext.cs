namespace Category.API.Data
{
    using MongoDB.Driver;

    public interface ICategoryContext
    {
        IMongoCollection<Entities.Category> Categories { get; }
    }
}
