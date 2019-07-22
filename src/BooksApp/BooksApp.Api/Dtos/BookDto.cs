using System;
using System.Collections.Generic;

namespace BooksApp.Api.Dtos
{
	public class BookDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Uri ReviewUrl { get; set; }
		public List<Guid> Authors { get; set; }
	}
}
