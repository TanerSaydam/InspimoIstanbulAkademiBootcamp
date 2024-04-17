using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockTypes.UpdateStockType;

internal sealed class UpdateStockTypeCommandHandler(
    IStockTypeRepository stockTypeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateStockTypeCommand>
{
    public async Task Handle(UpdateStockTypeCommand request, CancellationToken cancellationToken)
    {
        StockType stockType = await stockTypeRepository
            .GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if(stockType is null)
        {
            throw new ArgumentException("Stok türü bulunamadı");
        }

        if(stockType.Name != request.Name)
        {
            bool isNameExists = await stockTypeRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isNameExists)
            {
                throw new ArgumentException("Stok türü adı daha önce kullanılmış");
            }
        }

        stockType.Name = request.Name;
        stockType.IsActive = request.IsActive;

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
