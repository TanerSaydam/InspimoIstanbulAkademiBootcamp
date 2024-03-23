using AutoMapper;
using eBiletServer.Application.Services;
using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using GenericRepository;
using MediatR;

namespace eBiletServer.Application.Features.Buses.UpdateBus;

internal sealed class UpdateBusCommandHandler(
    IBusRepository busRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateBusCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateBusCommand request, CancellationToken cancellationToken)
    {
        Bus? bus = await busRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);
        if (bus is null)
        {
            return Result<string>.Failure("Bus not found");
        }

        if(bus.Plate != request.Plate)
        {
            bool isPlateExists = await busRepository.AnyAsync(p=> p.Plate == request.Plate, cancellationToken);
            if (isPlateExists)
            {
                return Result<string>.Failure("Plate already exists");
            }
        }

        mapper.Map(request, bus);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Bus update is sucessful");
    }
}
