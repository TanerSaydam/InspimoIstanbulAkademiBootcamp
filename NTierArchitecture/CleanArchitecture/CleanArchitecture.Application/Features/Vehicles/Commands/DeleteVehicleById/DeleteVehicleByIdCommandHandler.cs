using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Features.Vehicles.Commands.DeleteVehicleById;
internal sealed class DeleteVehicleByIdCommandHandler(
    IVehicleRepository vehicleRepository) : IRequestHandler<DeleteVehicleByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteVehicleByIdCommand request, CancellationToken cancellationToken)
    {
        await vehicleRepository.DeleteByIdAsync(request.Id, cancellationToken);

        return "Delete is successful";
    }
}
