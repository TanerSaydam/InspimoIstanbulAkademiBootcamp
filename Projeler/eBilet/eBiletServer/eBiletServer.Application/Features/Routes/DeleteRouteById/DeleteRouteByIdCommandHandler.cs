using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using GenericRepository;
using MediatR;

namespace eBiletServer.Application.Features.Routes.DeleteRouteById;

internal sealed class DeleteRouteByIdCommandHandler(
    IRouteRepository routeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteRouteByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteRouteByIdCommand request, CancellationToken cancellationToken)
    {
        Route route = await routeRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (route is null)
        {
            return Result<string>.Failure("Route not found");
        }

        routeRepository.Delete(route);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Delete is successful");
    }
}
