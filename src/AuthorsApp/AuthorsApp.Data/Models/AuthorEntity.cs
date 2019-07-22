using System;
using System.Collections.Generic;

namespace AuthorsApp.Data.Models
{
	public class AuthorEntity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Nationality { get; set; }
		public List<Guid> Books { get; set; }
	}
}
