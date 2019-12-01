namespace WebAPI.Models
{
	public class NflDataSettings : INflDataSettings
	{
		public string UpdateUrl { get; set; }
	}

	public interface INflDataSettings
	{
		string UpdateUrl { get; set; }
	}
}
