using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

using WebAPI.Models;

namespace WebAPI.Services
{
	public class TeamService : MongoService<Team>
	{
		public TeamService(IPoolDatabaseSettings settings)
		{
			_collection = ConnectDB(settings).GetCollection<Team>(settings.TeamsCollection);
		}

		public Team Get(string shortName) =>
			_collection.Find(team => team.ShortName.Equals(shortName)).Limit(1).FirstOrDefault();

		public void Update(string shortName, Team newTeam) =>
			_collection.ReplaceOne(team => team.ShortName.Equals(shortName), newTeam);

		public void Remove(Team toRemove) =>
			_collection.DeleteOne(team => team.ShortName.Equals(toRemove.ShortName));

		public void Remove(string shortName) =>
			_collection.DeleteOne(team => team.ShortName.Equals(shortName));
	}
}
