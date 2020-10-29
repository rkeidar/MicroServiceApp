using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace User.API.Entities
{
    public class UserEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
