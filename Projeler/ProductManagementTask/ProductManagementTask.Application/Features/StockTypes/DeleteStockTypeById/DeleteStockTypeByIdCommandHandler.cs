using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockTypes.DeleteStockTypeById;

internal sealed class DeleteStockTypeByIdCommandHandler(
    IStockTypeRepository stockTypeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteStockTypeByIdCommand>
{
    public async Task Handle(DeleteStockTypeByIdCommand request, CancellationToken cancellationToken)
    {
        StockType stockType = await stockTypeRepository
            .GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        if (stockType is null)
        {
            throw new ArgumentException("Stok türü bulunamadı");
        }

        stockTypeRepository.Delete(stockType);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
