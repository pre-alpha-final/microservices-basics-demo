using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApp.Domain.Models;

namespace BooksApp.Data.Services
{
	public interface IBookRepository
	{
		Task<IEnumerable<Book>> GetAll();
		Task<Book> Get(Guid id);
	}
}
