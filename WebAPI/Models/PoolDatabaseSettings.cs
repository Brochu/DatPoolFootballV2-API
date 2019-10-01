namespace WebAPI.Models
{
	public class PoolDatabaseSettings : IPoolDatabaseSettings
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public string TeamsCollection { get; set; }
	}

	public interface IPoolDatabaseSettings
	{
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
		string TeamsCollection { get; set; }
	}
}
