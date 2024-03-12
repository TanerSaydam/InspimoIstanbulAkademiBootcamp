using eBiletServer.Application.Features.Auth.Register;
using eBiletServer.Prestantion.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eBiletServer.Prestantion.Controllers;
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
