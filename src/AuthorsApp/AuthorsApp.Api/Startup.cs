using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace AuthorsApp.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			//services.AddTransient<IRemotingProxy, RemotingProxy>();
			//services.AddTransient<IConfigHelper, ConfigHelper>();
			services.AddSwaggerGen(e =>
			{
				e.SwaggerDoc("api", new Info
				{
					Title = "AuthorsApp title",
					Version = "v1",
				});
				e.IncludeXmlComments(Path.Combine(
					PlatformServices.Default.Application.ApplicationBasePath,
					typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml"));
				e.EnableAnnotations();
			});
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/authors-v1/swagger/api/swagger.json", "v1");
			});

			app.UseMvc();
		}
	}
}
