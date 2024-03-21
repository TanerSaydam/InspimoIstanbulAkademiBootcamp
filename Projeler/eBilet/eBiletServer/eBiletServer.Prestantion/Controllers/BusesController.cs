using eBiletServer.Application.Features.Buses.CreateBus;
using eBiletServer.Application.Features.Buses.DeleteBusById;
using eBiletServer.Application.Features.Buses.GetAllBus;
using eBiletServer.Application.Features.Buses.UpdateBus;
using eBiletServer.Prestantion.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eBiletServer.Prestantion.Controllers;
public sealed class BusesController : ApiController
{
    public BusesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBusCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBusCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteBusByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllBusQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return StatusCode(response.StatusCode, response);
    }
}
