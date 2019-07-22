using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorsApp.Domain.Remoting;
using BooksApp.Api.Dtos;
using BooksApp.Core.Services;
using BooksApp.Infrastructure;
using BooksApp.Infrastructure.Config;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BooksApp.Api.Controllers
{
	[Route("")]
	public class BooksController : Controller
	{
		private readonly IBookService _bookService;
		private readonly IRemotingProxy _remotingProxy;
		private readonly IConfigHelper _configHelper;

		public BooksController(IBookService bookService, IRemotingProxy remotingProxy,
			IConfigHelper configHelper)
		{
			_bookService = bookService;
			_remotingProxy = remotingProxy;
			_configHelper = configHelper;
		}

		/// <summary>
		/// Get all books
		/// </summary>
		/// <remarks>
		/// Returns a list of all books
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(GetAll))]
		public async Task<IActionResult> GetAll()
		{
			var books = await _bookService.GetAll();
			return Ok(books.Take(20).Select(e => new BookDto
			{
				Id = e.Id,
				Name = e.Name,
				ReviewUrl = e.ReviewUrl,
				Authors = e.Authors
			}));
		}

		/// <summary>
		/// Get book by id
		/// </summary>
		/// <remarks>
		/// Returns a books
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(Get))]
		[Route("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var book = await _bookService.Get(id);
			var authors = new List<Author>();
			foreach (var authorId in book.Authors)
			{
				var author = await CreateAuthorsAppRemotingService().Get(authorId);
				authors.Add(new Author
				{
					Id = author.Id,
					Name = author.Name,
					Nationality = author.Nationality
				});
			}

			return Ok(new BookWithAuthorsDto
			{
				Id = book.Id,
				Name = book.Name,
				ReviewUrl = book.ReviewUrl,
				Authors = authors
			});
		}

		private IAuthorsAppRemoting CreateAuthorsAppRemotingService()
		{
			return _remotingProxy.Create<IAuthorsAppRemoting>(new Uri(_configHelper.Remoting.AuthorsAppFabricAddress));
		}
	}
}
