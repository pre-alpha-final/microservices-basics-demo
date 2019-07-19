using System.Collections.Generic;
using System.Fabric;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace AuthorsApp.Api
{
	internal sealed class Api : StatelessService
	{
		public Api(StatelessServiceContext context)
			: base(context)
		{ }

		protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
		{
			return new ServiceInstanceListener[]
			{
				new ServiceInstanceListener(serviceContext =>
					new HttpSysCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
					{
						return new WebHostBuilder()
							.UseHttpSys(options =>
							{
								options.UrlPrefixes.Add("http://+:80/authors-v1/");
								options.Authentication.Schemes = AuthenticationSchemes.None;
								options.Authentication.AllowAnonymous = true;
								options.MaxConnections = null;
							})
							.ConfigureServices(services => services.AddSingleton<StatelessServiceContext>(serviceContext))
							.UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
							.UseContentRoot(Directory.GetCurrentDirectory())
							.UseStartup<Startup>()
							.UseUrls(url)
							.Build();
					}))
			};
		}
	}
}
