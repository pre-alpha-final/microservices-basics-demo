using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AuthorsApp.Remoting
{
	internal sealed class Remoting : StatelessService
	{
		public Remoting(StatelessServiceContext context)
			: base(context)
		{ }

		protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
		{
			return new ServiceInstanceListener[0];
		}

		protected override async Task RunAsync(CancellationToken cancellationToken)
		{
			long iterations = 0;

			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();

				ServiceEventSource.Current.ServiceMessage(this.Context, "Working-{0}", ++iterations);

				await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
			}
		}
	}
}
