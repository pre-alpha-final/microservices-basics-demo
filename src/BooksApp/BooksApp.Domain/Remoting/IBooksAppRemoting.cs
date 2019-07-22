using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Domain.Models;

namespace BooksApp.Domain.Remoting
{
	public interface IBooksAppRemoting
	{
		Task<IEnumerable<Book>> GetAll();
		Task<Book> Get(Guid id);
	}
}
