using Azure.Core;
using CleanArchitecture.Application.Features.Vehicles.Commands.CreateVehicle;
using CleanArchitecture.Application.Features.Vehicles.Commands.DeleteVehicleById;
using CleanArchitecture.Application.Features.Vehicles.Commands.UpdateVehicle;
using CleanArchitecture.Application.Features.Vehicles.Queries.GetAllVehicles;
using CleanArchitecture.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class VehiclesController(
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        GetAllVehicleQuery request = new();
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateVehicleCommand request, CancellationToken cancellationToken)
    {        
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteById(DeleteVehicleByIdCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }
}
