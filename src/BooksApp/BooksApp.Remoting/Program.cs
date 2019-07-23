using System;
using System.Diagnostics;
using System.Threading;
using Autofac;
using BooksApp.Core.Services;
using BooksApp.Core.Services.Implementation;
using BooksApp.Data.Services;
using BooksApp.Data.Services.Implementation;
using BooksApp.Infrastructure;
using BooksApp.Infrastructure.Config;
using BooksApp.Infrastructure.Config.Implementations;
using BooksApp.Infrastructure.Implementations;
using Microsoft.ServiceFabric.Services.Runtime;

namespace BooksApp.Remoting
{
	internal static class Program
	{
		private static void Main()
		{
			try
			{
				var builder = new ContainerBuilder();
				builder.RegisterType<BookService>().As<IBookService>();
				builder.RegisterType<BookRepositoryMock>().As<IBookRepository>();
				builder.RegisterType<RemotingProxy>().As<IRemotingProxy>();
				builder.RegisterType<ConfigHelper>().As<IConfigHelper>();
				var container = builder.Build();

				ServiceRuntime.RegisterServiceAsync("BooksApp.RemotingType", context => new Remoting(
					context,
					container.Resolve<IBookService>()
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
