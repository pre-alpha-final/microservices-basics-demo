using System;
using System.Collections.Generic;

// Should be acquired from directly from target remoting assembly (e.g. via nuget)
namespace BooksApp.Domain.Models
{
	public class Book
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Uri ReviewUrl { get; set; }
		public List<Guid> Authors { get; set; }
	}
}
