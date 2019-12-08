using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

using WebAPI.Models;

namespace WebAPI.Services
{
	public class MatchService : MongoService<Match>
	{
		public MatchService(IPoolDatabaseSettings settings)
		{
			_collection = ConnectDB(settings).GetCollection<Match>(settings.MatchesCollection);
		}

		public bool Exists(string id) => Get(id) != null;

		public Match Get(string id) =>
			_collection.Find(match => match.Id.Equals(id)).Limit(1).FirstOrDefault();

		public Match[] Get(int season, int week) =>
			_collection.Find(match => match.Season == season && match.Week == week).ToEnumerable().ToArray();

		public void BatchWeek(IEnumerable<Match> matches)
		{
			List<Match> toInsert = new List<Match>();
			foreach (Match m in matches)
			{
				if (Exists(m.Id))
				{
					Update(m.Id, m);
				}
				else
				{
					toInsert.Add(m);
				}
			}

			if (toInsert.Count > 0)
			{
				_collection.InsertMany(toInsert);
			}
		}

		public void Update(string id, Match newMatch) =>
			_collection.ReplaceOne(match => match.Id.Equals(id), newMatch);

		public void Remove(Match toRemove) =>
			_collection.DeleteOne(match => match.Id.Equals(toRemove.Id));

		public void Remove(string id) =>
			_collection.DeleteOne(match => match.Id.Equals(id));
	}
}
