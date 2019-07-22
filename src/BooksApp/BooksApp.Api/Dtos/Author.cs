using System;

namespace BooksApp.Api.Dtos
{
	public class Author
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
	}
}
