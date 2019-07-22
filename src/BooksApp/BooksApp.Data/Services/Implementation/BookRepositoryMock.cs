using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Data.Models;
using BooksApp.Domain.Models;

namespace BooksApp.Data.Services.Implementation
{
	public class BookRepositoryMock : IBookRepository
	{
		private static readonly List<BookEntity> BookEntities = new List<BookEntity>
		{
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
				Name = "Equal Rites",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Equal_Rites"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
				Name = "Wyrd Sisters",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Wyrd_Sisters"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
				Name = "Witches Abroad",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Witches_Abroad"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000006"),
				Name = "Lords and Ladies",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Lords_and_Ladies"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000007"),
				Name = "Maskerade",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Maskerade"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000008"),
				Name = "Carpe Jugulum",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Carpe_Jugulum"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000009"),
				Name = "The Wee Free Men",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:The_Wee_Free_Men"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000010"),
				Name = "A Hat Full of Sky",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:A_Hat_Full_of_Sky"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000011"),
				Name = "Wintersmith",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:Wintersmith"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000012"),
				Name = "I Shall Wear Midnight",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:I_Shall_Wear_Midnight"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000013"),
				Name = "The Shepherd's Crown",
				ReviewUrl = new Uri("https://wiki.lspace.org/mediawiki/Book:The_Shepherd%27s_Crown"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000001") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000014"),
				Name = "Snow White",
				ReviewUrl = new Uri("https://en.wikipedia.org/wiki/Snow_White"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000002") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000015"),
				Name = "Sleeping Beauty",
				ReviewUrl = new Uri("https://en.wikipedia.org/wiki/Sleeping_Beauty"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000002") }
			},
			new BookEntity
			{
				Id = Guid.Parse("00000000-0000-0000-0000-000000000016"),
				Name = "Hansel and Gretel",
				ReviewUrl = new Uri("https://en.wikipedia.org/wiki/Hansel_and_Gretel"),
				Authors = new List<Guid> { Guid.Parse("00000000-0000-0000-0000-000000000002") }
			},
		};

		public async Task<IEnumerable<Book>> GetAll()
		{
			return BookEntities.Select(e => new Book
			{
				Id = e.Id,
				Name = e.Name,
				ReviewUrl = e.ReviewUrl,
				Authors = e.Authors
			});
		}

		public async Task<Book> Get(Guid id)
		{
			var bookEntity = BookEntities.FirstOrDefault(e => e.Id == id);
			return bookEntity == null
				   ? null
				   : new Book
				   {
					   Id = bookEntity.Id,
					   Name = bookEntity.Name,
					   ReviewUrl = bookEntity.ReviewUrl,
					   Authors = bookEntity.Authors,
				   };
		}
	}
}
