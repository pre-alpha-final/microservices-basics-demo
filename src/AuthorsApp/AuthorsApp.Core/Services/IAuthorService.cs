using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Domain.Models;

namespace AuthorsApp.Core.Services
{
	public interface IAuthorService
	{
		Task<IEnumerable<Author>> GetAll();
		Task<Author> Get(Guid id);
	}
}
