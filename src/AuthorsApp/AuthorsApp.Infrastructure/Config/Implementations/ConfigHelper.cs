namespace AuthorsApp.Infrastructure.Config.Implementations
{
	public class ConfigHelper : IConfigHelper
	{
		public IRemoting Remoting { get; set; } = new Remoting();
	}
}
