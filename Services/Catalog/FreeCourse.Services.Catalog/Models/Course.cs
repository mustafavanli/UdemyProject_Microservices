using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace FreeCourse.Services.API.Models
{
    public class Course
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Price { get; set; }

        public string Description { get; set; }
        public string Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature Feature { get; set; }



        [BsonIgnore]
        public Category Category { get; set; }
    }
}
