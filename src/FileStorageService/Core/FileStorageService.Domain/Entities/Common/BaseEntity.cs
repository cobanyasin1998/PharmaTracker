using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FileStorageService.Domain.Entities.Common
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
