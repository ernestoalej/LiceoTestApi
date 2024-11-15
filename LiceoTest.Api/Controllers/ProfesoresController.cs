using LiceoTest.Application.UseCases.Profesores.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiceoTest.API.Controllers
{	
	public class ProfesoresController : BaseController
	{
		public ProfesoresController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet("list")]		
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesDefaultResponseType]
		public async Task<IActionResult> GetByState(CancellationToken cancellationToken)
		{
			var result = await Mediator.Send(new GetProfesoresListQuery(), cancellationToken);

			if (!result.Any()) return NoContent();

			return Ok(result);
		}
	}
}
