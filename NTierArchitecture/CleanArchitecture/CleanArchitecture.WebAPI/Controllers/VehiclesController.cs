using Azure;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Validators;
using CleanArchitecture.Domain.DTOs;
using CleanArchitecture.WebAPI.AOP;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class VehiclesController(
    IVehicleService vehicleService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await vehicleService.GetAllAsync(cancellationToken);
        return StatusCode(response.StatuCode, response);
    }
    [HttpPost]
    // [ValidationFilter<VehicleDtoValidator>]
    public async Task<IActionResult> Create(VehicleDto request, CancellationToken cancellationToken)
    {
        var response = await vehicleService.AddAsync(request, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, VehicleDto request, CancellationToken cancellationToken)
    {
        var response = await vehicleService.UpdateAsync(id, request, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        var response = await vehicleService.DeleteByIdAsync(id, cancellationToken);
        return StatusCode(response.StatuCode, response);
    }
}
