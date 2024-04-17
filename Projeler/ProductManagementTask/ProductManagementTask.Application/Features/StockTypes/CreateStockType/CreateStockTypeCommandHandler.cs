using GenericRepository;
using MediatR;
using ProductManagementTask.Domain.Entities;
using ProductManagementTask.Domain.Repositories;

namespace ProductManagementTask.Application.Features.StockTypes.CreateStockType;

internal sealed class CreateStockTypeCommandHandler(
    IStockTypeRepository stockTypeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateStockTypeCommand>
{
    public async Task Handle(CreateStockTypeCommand request, CancellationToken cancellationToken)
    {
        bool isStockTypeExists = await stockTypeRepository.AnyAsync(p=> p.Name == request.Name, cancellationToken); 

        if(isStockTypeExists)
        {
            throw new ArgumentException("Stok türü daha önce kaydedilmiş");
        }

        StockType stockType = new()
        {
            Name = request.Name
        };

        await stockTypeRepository.AddAsync(stockType, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
