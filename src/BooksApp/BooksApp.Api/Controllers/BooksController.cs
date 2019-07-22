using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BooksApp.Api.Controllers
{
	[Route("")]
	public class BooksController : Controller
	{
		/// <summary>
		/// Get all books
		/// </summary>
		/// <remarks>
		/// Returns a list of all books
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(GetAll))]
		public async Task<IActionResult> GetAll()
		{
			return Ok(new List<string>());
		}

		/// <summary>
		/// Get book by id
		/// </summary>
		/// <remarks>
		/// Returns a books
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(Get))]
		public async Task<IActionResult> Get(Guid id)
		{
			return Ok(new List<string>());
		}
	}
}
