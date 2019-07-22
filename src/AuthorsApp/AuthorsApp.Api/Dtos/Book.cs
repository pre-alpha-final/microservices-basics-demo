using System;

namespace AuthorsApp.Api.Dtos
{
	public class Book
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Uri ReviewUrl { get; set; }
	}
}
