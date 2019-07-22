using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Infrastructure;
using BooksApp.Domain.Models;

// Should be acquired from directly from target remoting assembly (e.g. via nuget)
namespace BooksApp.Domain.Remoting
{
	public interface IBooksAppRemoting : IRemotingBase
	{
		Task<IEnumerable<Book>> GetAll();
		Task<Book> Get(Guid id);
	}
}
