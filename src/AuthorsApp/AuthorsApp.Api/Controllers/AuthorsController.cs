using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuthorsApp.Api.Controllers
{
	[Route("")]
	public class AuthorsController : Controller
	{
		/// <summary>
		/// Get all authors
		/// </summary>
		/// <remarks>
		/// Returns a list of all authors
		/// </remarks>
		[HttpGet, SwaggerOperation(OperationId = nameof(GetAll))]
		public async Task<IActionResult> GetAll()
		{
			return Ok(new List<string>());
		}
	}
}
