using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

using WebAPI.Models;

namespace WebAPI.Services
{
	public class TeamService
	{
		private readonly IMongoCollection<Team> _teams;

		public TeamService(IPoolDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			var database = client.GetDatabase(settings.DatabaseName);

			_teams = database.GetCollection<Team>(settings.TeamsCollection);
		}

		public List<Team> Get() =>
			_teams.Find(team => true).ToList();

		public Team Get(string shortName) =>
			_teams.Find(team => team.ShortName.Equals(shortName)).FirstOrDefault();

		public Team Create(Team team)
		{
			_teams.InsertOne(team);
			return team;
		}

		public void Update(string shortName, Team newTeam) =>
			_teams.ReplaceOne(team => team.ShortName.Equals(shortName), newTeam);

		public void Remove(Team toRemove) =>
			_teams.DeleteOne(team => team.ShortName.Equals(toRemove.ShortName));

		public void Remove(string shortName) =>
			_teams.DeleteOne(team => team.ShortName.Equals(shortName));
	}
}
