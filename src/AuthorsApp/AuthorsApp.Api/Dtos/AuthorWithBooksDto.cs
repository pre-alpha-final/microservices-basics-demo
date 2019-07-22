using System;
using System.Collections.Generic;

namespace AuthorsApp.Api.Dtos
{
	public class AuthorWithBooksDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public List<Book> Books { get; set; }
	}
}
