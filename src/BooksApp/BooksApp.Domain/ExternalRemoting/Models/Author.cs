using System;
using System.Collections.Generic;

// Should be acquired from directly from target remoting assembly (e.g. via nuget)
namespace AuthorsApp.Domain.Models
{
	public class Author
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public List<Guid> Books { get; set; }
	}
}
