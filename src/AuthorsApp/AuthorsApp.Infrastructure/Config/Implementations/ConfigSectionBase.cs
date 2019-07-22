using System.Fabric;
using System.Runtime.CompilerServices;

namespace AuthorsApp.Infrastructure.Config.Implementations
{
	public abstract class ConfigSectionBase
	{
		public string GetConfig(string section, [CallerMemberName] string key = "")
		{
			var context = FabricRuntime.GetActivationContext();
			var config = context.GetConfigurationPackageObject("Config").Settings.Sections[section];

			return config.Parameters[key].Value;
		}
	}
}
