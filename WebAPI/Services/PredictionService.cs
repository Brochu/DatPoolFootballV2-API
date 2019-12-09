using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

using WebAPI.Models;

namespace WebAPI.Services
{
	public class PredictionService : MongoService<Prediction>
	{
		public PredictionService(IPoolDatabaseSettings settings)
		{
			_collection = ConnectDB(settings).GetCollection<Prediction>(settings.PredictionsCollection);
		}

		public Prediction Get(string id) =>
			_collection.Find(pick => pick.Id.Equals(id)).Limit(1).FirstOrDefault();

		public Prediction[] GetMatchPredictions(string matchId) =>
			_collection.Find(pick => pick.MatchId.Equals(matchId)).ToEnumerable().ToArray();

		public Prediction[] GetPoolerPredictions(string poolerId) =>
			_collection.Find(pick => pick.PoolerId.Equals(poolerId)).ToEnumerable().ToArray();

		public Prediction[] Get(string matchId, string poolerId) =>
			_collection.Find(pick => pick.MatchId.Equals(matchId) && pick.PoolerId.Equals(poolerId)).ToEnumerable().ToArray();

		public void Update(string id, Prediction newPick) =>
			_collection.ReplaceOne(pick => pick.Id.Equals(id), newPick);
		// TODO: Add other update func to only change the pick field

		public void Remove(Prediction toRemove) =>
			_collection.DeleteOne(pick => pick.Id.Equals(toRemove.Id));

		public void Remove(string id) =>
			_collection.DeleteOne(pick => pick.Id.Equals(id));
	}
}
