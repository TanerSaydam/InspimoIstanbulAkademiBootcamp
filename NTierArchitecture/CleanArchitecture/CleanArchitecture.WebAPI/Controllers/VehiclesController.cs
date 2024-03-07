using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.DTOs;
using Microsoft.AspNetCore.Http;
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
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VehicleDto request, CancellationToken cancellationToken)
    {
        await vehicleService.AddAsync(request, cancellationToken);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, VehicleDto request, CancellationToken cancellationToken)
    {
        await vehicleService.UpdateAsync(id, request, cancellationToken);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationToken)
    {
        await vehicleService.DeleteByIdAsync(id, cancellationToken);
        return NoContent();
    }
}
