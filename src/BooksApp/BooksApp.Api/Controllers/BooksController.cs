using System;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Api.Dtos;
using BooksApp.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BooksApp.Api.Controllers
{
	[Route("")]
	public class BooksController : Controller
	{
		private readonly IBookService _bookService;

		public BooksController(IBookService bookService)
		{
			_bookService = bookService;
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
			return Ok(new BookDto
			{
				Id = book.Id,
				Name = book.Name,
				ReviewUrl = book.ReviewUrl,
				Authors = book.Authors
			});
		}
	}
}
