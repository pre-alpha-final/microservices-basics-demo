using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Domain.Models;

namespace AuthorsApp.Domain.Remoting
{
	public interface IAuthorsAppRemoting
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Get(Guid id);
	}
}
