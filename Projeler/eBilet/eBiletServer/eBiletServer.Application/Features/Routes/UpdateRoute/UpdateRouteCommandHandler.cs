using AutoMapper;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using GenericRepository;
using MediatR;

namespace eBiletServer.Application.Features.Routes.UpdateRoute;

internal sealed class UpdateRouteCommandHandler(
    IRouteRepository routeRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateRouteCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
    {
        Route route = await routeRepository.GetByExpressionWithTrackingAsync(p=> p.Id == request.Id, cancellationToken);

        if(route is null)
        {
            return Result<string>.Failure("Route not found");
        }

        mapper.Map(request, route);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<string>.Succeed("Route update is successful");
    }
}



