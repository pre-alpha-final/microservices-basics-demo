using System;
using System.Diagnostics;
using System.Threading;
using AuthorsApp.Core.Services;
using AuthorsApp.Core.Services.Implementation;
using AuthorsApp.Data.Services;
using AuthorsApp.Data.Services.Implementation;
using AuthorsApp.Infrastructure;
using AuthorsApp.Infrastructure.Config;
using AuthorsApp.Infrastructure.Config.Implementations;
using AuthorsApp.Infrastructure.Implementations;
using Autofac;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AuthorsApp.Remoting
{
	internal static class Program
	{
		private static void Main()
		{
			try
			{
				var builder = new ContainerBuilder();
				builder.RegisterType<AuthorService>().As<IAuthorService>();
				builder.RegisterType<AuthorRepositoryMock>().As<IAuthorRepository>();
				builder.RegisterType<RemotingProxy>().As<IRemotingProxy>();
				builder.RegisterType<ConfigHelper>().As<IConfigHelper>();
				var container = builder.Build();

				ServiceRuntime.RegisterServiceAsync("AuthorsApp.RemotingType", context => new Remoting(
					context,
					container.Resolve<IAuthorService>()
					)).GetAwaiter().GetResult();

				ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(Remoting).Name);

				Thread.Sleep(Timeout.Infinite);
			}
			catch (Exception e)
			{
				ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
				throw;
			}
		}
	}
}
