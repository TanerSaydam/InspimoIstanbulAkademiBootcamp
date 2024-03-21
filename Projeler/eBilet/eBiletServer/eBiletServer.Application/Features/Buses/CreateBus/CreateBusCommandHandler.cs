using AutoMapper;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using GenericRepository;
using MediatR;

namespace eBiletServer.Application.Features.Buses.CreateBus;

internal sealed class CreateBusCommandHandler(
    IBusRepository busRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateBusCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateBusCommand request, CancellationToken cancellationToken)
    {
        bool isPlateExists = await busRepository.AnyAsync(p => p.Plate == request.Plate, cancellationToken);

        if (isPlateExists)
        {
            return Result<string>.Failure("Plate already exists");
        }

        Bus bus = mapper.Map<Bus>(request);

        await busRepository.AddAsync(bus, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Bus create is successful");
    }
}
