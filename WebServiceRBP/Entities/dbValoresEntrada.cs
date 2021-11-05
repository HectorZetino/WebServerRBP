using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebServiceRBP.Entities
{
    public class dbValoresEntrada
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string NoRestado { get; set; }
    }
}
