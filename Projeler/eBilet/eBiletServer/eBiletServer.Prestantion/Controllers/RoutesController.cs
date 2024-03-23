using eBiletServer.Application.Features.Routes.CreateRoute;
using eBiletServer.Application.Features.Routes.DeleteRouteById;
using eBiletServer.Application.Features.Routes.GetAllRoute;
using eBiletServer.Application.Features.Routes.UpdateRoute;
using eBiletServer.Prestantion.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eBiletServer.Prestantion.Controllers;
public sealed class RoutesController : ApiController
{
    public RoutesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllRouteQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteRouteByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
