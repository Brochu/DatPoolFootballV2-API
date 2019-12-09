using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAPI.Models
{
	public class Match : MongoModelBase
	{
		[BsonId]
		public string Id { get; set; }

		public int Season { get; set; }
		public int Week { get; set; }

		public DayOfWeek Day { get; set; }
		public string Time { get; set; }
		public bool IsFinal { get; set; }

		public string HomeCode { get; set; }
		public string HomeName { get; set; }
		public int HomeScore { get; set; }

		public string VisitCode { get; set; }
		public string VisitName { get; set; }
		public int VisitScore { get; set; }
	}
}
