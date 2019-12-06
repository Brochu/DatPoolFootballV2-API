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

		public Match Get(string id) =>
			_collection.Find(match => match.Id.Equals(id)).FirstOrDefault();

		public void Update(string id, Match newMatch) =>
			_collection.ReplaceOne(match => match.Id.Equals(id), newMatch);

		public void Remove(Match toRemove) =>
			_collection.DeleteOne(match => match.Id.Equals(toRemove.Id));

		public void Remove(string id) =>
			_collection.DeleteOne(match => match.Id.Equals(id));
	}
}
