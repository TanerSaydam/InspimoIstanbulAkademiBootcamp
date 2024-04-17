using MediatR;

namespace ProductManagementTask.Application.Features.StockTypes.UpdateStockType;
public sealed record UpdateStockTypeCommand(
    int Id,
    string Name,
    bool IsActive) : IRequest;
