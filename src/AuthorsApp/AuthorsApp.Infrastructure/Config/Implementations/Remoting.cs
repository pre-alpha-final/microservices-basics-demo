namespace AuthorsApp.Infrastructure.Config.Implementations
{
	public class Remoting : ConfigSectionBase, IRemoting
	{
		public string AuthorsAppFabricAddress => GetConfig(GetType().Name);
	}
}
