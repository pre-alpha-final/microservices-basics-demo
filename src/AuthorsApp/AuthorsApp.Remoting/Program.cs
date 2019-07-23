using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AuthorsApp.Remoting
{
	internal static class Program
	{
		private static void Main()
		{
			try
			{
				ServiceRuntime.RegisterServiceAsync("AuthorsApp.RemotingType",
					context => new Remoting(context)).GetAwaiter().GetResult();

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
