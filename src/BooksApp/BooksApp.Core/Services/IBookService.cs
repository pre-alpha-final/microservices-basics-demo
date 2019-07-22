using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Domain.Models;

namespace BooksApp.Core.Services
{
	public interface IBookService
	{
		Task<IEnumerable<Book>> GetAll();
		Task<Book> Get(Guid id);
	}
}
