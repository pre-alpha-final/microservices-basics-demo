using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Domain.ExternalRemoting.Models;
using BooksApp.Infrastructure;

namespace BooksApp.Domain.ExternalRemoting
{
	public interface IAuthorsAppRemoting : IRemotingBase
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Get(Guid id);
	}
}
