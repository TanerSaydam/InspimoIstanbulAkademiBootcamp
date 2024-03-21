using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Domain.Utilities;
using GenericRepository;
using MediatR;

namespace eBiletServer.Application.Features.Buses.DeleteBusById;

internal sealed class DeleteBusByIdCommandHandler(
    IBusRepository busRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteBusByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteBusByIdCommand request, CancellationToken cancellationToken)
    {
        Bus? bus = await busRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if(bus is null)
        {
            return Result<string>.Failure("Bus not found");
        }

        busRepository.Delete(bus);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Bus delete is successful");
    }
}
