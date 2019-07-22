using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorsApp.Data.Models;
using AuthorsApp.Domain.Models;

namespace AuthorsApp.Data.Services.Implementation
{
	public class AuthorRepositoryMock : IAuthorRepository
	{
		private static readonly List<AuthorEntity> AuthorEntities = new List<AuthorEntity>
		{
			new AuthorEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
				Name = "Terry Pratchett",
				Nationality = "British",
				Books = new List<Guid>
				{
					Guid.Parse("00000000-0000-0000-0000-000000000003"),
					Guid.Parse("00000000-0000-0000-0000-000000000004"),
					Guid.Parse("00000000-0000-0000-0000-000000000005"),
					Guid.Parse("00000000-0000-0000-0000-000000000006"),
					Guid.Parse("00000000-0000-0000-0000-000000000007"),
					Guid.Parse("00000000-0000-0000-0000-000000000008"),
					Guid.Parse("00000000-0000-0000-0000-000000000009"),
					Guid.Parse("00000000-0000-0000-0000-000000000010"),
					Guid.Parse("00000000-0000-0000-0000-000000000011"),
					Guid.Parse("00000000-0000-0000-0000-000000000012"),
					Guid.Parse("00000000-0000-0000-0000-000000000013"),
				}
			},
			new AuthorEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
				Name = "Brothers Grimm",
				Nationality = "German",
				Books = new List<Guid>
				{
					Guid.Parse("00000000-0000-0000-0000-000000000014"),
					Guid.Parse("00000000-0000-0000-0000-000000000015"),
					Guid.Parse("00000000-0000-0000-0000-000000000016"),
				}
			}
		};

		public async Task<IEnumerable<Author>> GetAll()
		{
			return AuthorEntities.Select(e => new Author
			{
				Id = e.Id,
				Name = e.Name,
				Nationality = e.Nationality,
				Books = e.Books
			});
		}

		public async Task<Author> Get(Guid id)
		{
			var authorEntity = AuthorEntities.FirstOrDefault(e => e.Id == id);
			return authorEntity == null
				? null
				: new Author
				{
					Id = authorEntity.Id,
					Name = authorEntity.Name,
					Nationality = authorEntity.Nationality,
					Books = authorEntity.Books,
				};
		}
	}
}
