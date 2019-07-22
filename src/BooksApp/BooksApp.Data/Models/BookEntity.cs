using System;
using System.Collections.Generic;

namespace BooksApp.Data.Models
{
	public class BookEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Uri ReviewUrl { get; set; }
		public List<Guid> Authors { get; set; }
	}
}
