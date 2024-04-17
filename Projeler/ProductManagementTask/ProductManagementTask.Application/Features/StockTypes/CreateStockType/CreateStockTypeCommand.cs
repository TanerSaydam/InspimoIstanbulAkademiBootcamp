using MediatR;

namespace ProductManagementTask.Application.Features.StockTypes.CreateStockType;
public sealed record CreateStockTypeCommand(
    string Name) : IRequest;
