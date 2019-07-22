using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Domain.Models;

namespace AuthorsApp.Data.Services
{
	public interface IAuthorRepository
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Get(Guid id);
	}
}
