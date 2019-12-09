using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
	public enum Pick
	{
		Home,
		Visitor
	}

	public class Prediction : MongoModelBase
	{
		[BsonId]
		public string Id { get; set; }

		public string MatchId { get; set; }
		public string PoolerId { get; set; }
		public Pick Pick { get; set; }
	}
}
