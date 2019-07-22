using System.IO;
using System.Reflection;
using BooksApp.Core.Services;
using BooksApp.Core.Services.Implementation;
using BooksApp.Data.Services;
using BooksApp.Data.Services.Implementation;
using BooksApp.Infrastructure;
using BooksApp.Infrastructure.Config;
using BooksApp.Infrastructure.Config.Implementations;
using BooksApp.Infrastructure.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace BooksApp.Api
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
			services.AddTransient<IBookService, BookService>();
			services.AddTransient<IBookRepository, BookRepositoryMock>();
			services.AddTransient<IRemotingProxy, RemotingProxy>();
			services.AddTransient<IConfigHelper, ConfigHelper>();
			services.AddSwaggerGen(e =>
			{
				e.SwaggerDoc("api", new Info
				{
					Title = "BooksApp title",
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
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/books-v1/swagger/api/swagger.json", "v1");
			});

			app.UseMvc();
		}
	}
}
