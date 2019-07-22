using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorsApp.Data.Services;
using AuthorsApp.Domain.Models;
using AuthorsApp.Domain.Remoting;

namespace AuthorsApp.Core.Services.Implementation
{
	public class AuthorService : IAuthorService, IAuthorsAppRemoting
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorService(IAuthorRepository authorRepository)
		{
			_authorRepository = authorRepository;
		}

		public Task<IEnumerable<Author>> GetAll()
		{
			return _authorRepository.GetAll();
		}

		public Task<Author> Get(Guid id)
		{
			return _authorRepository.Get(id);
		}
	}
}
