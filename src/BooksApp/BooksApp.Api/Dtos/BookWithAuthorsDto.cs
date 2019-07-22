using System;
using System.Collections.Generic;

namespace BooksApp.Api.Dtos
{
	public class BookWithAuthorsDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Uri ReviewUrl { get; set; }
		public List<Author> Authors { get; set; }
	}
}
