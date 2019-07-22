using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Domain.Models;
using BooksApp.Infrastructure;

// Should be acquired from directly from target remoting assembly (e.g. via nuget)
namespace AuthorsApp.Domain.Remoting
{
	public interface IAuthorsAppRemoting : IRemotingBase
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Get(Guid id);
	}
}
