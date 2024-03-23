using AutoMapper;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using GenericRepository;
using MediatR;

namespace eBiletServer.Application.Features.Routes.CreateRoute;

internal sealed class CreateRouteCommandHandler(
    IRouteRepository routeRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateRouteCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
    {
        Route route = mapper.Map<Route>(request);

        await routeRepository.AddAsync(route, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Route create is successful");
    }
}
