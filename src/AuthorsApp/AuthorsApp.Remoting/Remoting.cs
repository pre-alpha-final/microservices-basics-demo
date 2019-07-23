using System;
using System.Collections.Generic;
using System.Fabric;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AuthorsApp.Core.Services;
using AuthorsApp.Domain.Models;
using AuthorsApp.Domain.Remoting;
using Castle.Core.Internal;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
namespace AuthorsApp.Remoting
{
	public class Remoting : StatelessService, IAuthorsAppRemoting
	{
		private readonly IAuthorService _authorService;

		public Remoting(StatelessServiceContext context, IAuthorService authorService)
			: base(context)
		{
			_authorService = authorService;
		}

		protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
		{
			return this.CreateServiceRemotingInstanceListeners();
		}

		public Task<IEnumerable<Author>> GetAll()
		{
			return _authorService.GetAll();
		}

		public Task<Author> Get(Guid id)
		{
			return _authorService.Get(id);
		}
	}
}
