using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Category.API.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("slug")]
        public string Slug { get; set; } = null!;

        [BsonElement("parentId")]
        public string? ParentId { get; set; }

        [BsonElement("place")]
        public string? Place { get; set; }

        [BsonElement("backgroundColor")]
        public string? BackgroundColor { get; set; }

        [BsonElement("categoryTitle")]
        public string? CategoryTitle { get; set; }

        [BsonElement("subCategories")]
        public List<Category>? SubCategories { get; set; } = new();

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [BsonElement("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }
    }
}
