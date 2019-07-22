using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Domain.ExternalRemoting.Models;
using AuthorsApp.Infrastructure;

namespace AuthorsApp.Domain.ExternalRemoting
{
	public interface IBooksAppRemoting : IRemotingBase
	{
		Task<IEnumerable<Book>> GetAll();
		Task<Book> Get(Guid id);
	}
}
