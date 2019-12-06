using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
	public class Team : MongoModelBase
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string ShortName { get; set; }
		public string FullName { get; set; }
		public string Division { get; set; }
	}
}
