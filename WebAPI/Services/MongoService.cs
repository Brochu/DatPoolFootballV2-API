using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

using WebAPI.Models;

namespace WebAPI.Services
{
	public abstract class MongoService<T> where T : MongoModelBase
	{
		protected IMongoCollection<T> _collection;

		protected IMongoDatabase ConnectDB(IPoolDatabaseSettings settings)
		{
			var client = new MongoClient(settings.ConnectionString);
			return client.GetDatabase(settings.DatabaseName);
		}

		public virtual List<T> Get() =>
			_collection.Find(item => true).ToList();

		public virtual T Create(T toAdd)
		{
			_collection.InsertOne(toAdd);
			return toAdd;
		}
	}
}
