using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LiceoTest.API;

[ApiController]
[Route("[controller]")]
public class BaseController(IMediator mediator) : ControllerBase {
	protected IMediator Mediator { get; } = mediator ?? throw new ArgumentNullException(nameof(mediator));

}
