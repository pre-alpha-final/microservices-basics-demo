namespace AuthorsApp.Infrastructure.Config.Implementations
{
	public class Remoting : ConfigSectionBase, IRemoting
	{
		public string BooksAppFabricAddress => GetConfig(GetType().Name);
	}
}
