using System;
using System.Collections.Generic;

namespace AuthorsApp.Domain.ExternalRemoting.Models
{
	public class Book
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Uri ReviewUrl { get; set; }
		public List<Guid> Authors { get; set; }
	}
}
