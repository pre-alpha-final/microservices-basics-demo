using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorsApp.Api.Dtos;
using AuthorsApp.Core.Services;
using AuthorsApp.Infrastructure;
using AuthorsApp.Infrastructure.Config;
using BooksApp.Domain.Remoting;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthorsApp.Api.Controllers
{
	[Route("")]
	public class AuthorsController : Controller
	{
		private readonly IAuthorService _authorService;
		private readonly IRemotingProxy _remotingProxy;
		private readonly IConfigHelper _configHelper;

		public AuthorsController(IAuthorService authorService, IRemotingProxy remotingProxy,
			IConfigHelper configHelper)
		{
			_authorService = authorService;
			_remotingProxy = remotingProxy;
			_configHelper = configHelper;
		}

		/// <summary>
		/// Get all authors
		/// </summary>
		/// <remarks>
		/// Returns a list of all authors
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(GetAll))]
		public async Task<IActionResult> GetAll()
		{
			var authors = await _authorService.GetAll();
			return Ok(authors.Take(20).Select(e => new AuthorDto
			{
				Id = e.Id,
				Name = e.Name,
				Nationality = e.Nationality,
				Books = e.Books
			}));
		}

		/// <summary>
		/// Get author by id
		/// </summary>
		/// <remarks>
		/// Returns author
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(Get))]
		[Route("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var author = await _authorService.Get(id);
			var books = new List<Book>();
			foreach (var bookId in author.Books)
			{
				var book = await CreateBooksAppRemotingService().Get(bookId);
				books.Add(new Book
				{
					Id = book.Id,
					Name = book.Name,
					ReviewUrl = book.ReviewUrl
				});
			}

			return Ok(new AuthorWithBooksDto
			{
				Id = author.Id,
				Name = author.Name,
				Nationality = author.Nationality,
				Books = books
			});
		}

		private IBooksAppRemoting CreateBooksAppRemotingService()
		{
			return _remotingProxy.Create<IBooksAppRemoting>(new Uri(_configHelper.Remoting.BooksAppFabricAddress));
		}
	}
}
