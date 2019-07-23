using System;
using System.Collections.Generic;
using System.Fabric;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BooksApp.Core.Services;
using BooksApp.Domain.Models;
using BooksApp.Domain.Remoting;
using Castle.Core.Internal;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

[assembly: InternalsVisibleTo(InternalsVisible.ToDynamicProxyGenAssembly2)]
namespace BooksApp.Remoting
{
	public class Remoting : StatelessService, IBooksAppRemoting
	{
		private readonly IBookService _bookService;

		public Remoting(StatelessServiceContext context, IBookService bookService)
			: base(context)
		{
			_bookService = bookService;
		}

		protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
		{
			return this.CreateServiceRemotingInstanceListeners();
		}

		public Task<IEnumerable<Book>> GetAll()
		{
			return _bookService.GetAll();
		}

		public Task<Book> Get(Guid id)
		{
			return _bookService.Get(id);
		}
	}
}
