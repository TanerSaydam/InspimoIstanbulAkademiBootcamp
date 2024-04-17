using MediatR;

namespace ProductManagementTask.Application.Features.StockTypes.DeleteStockTypeById;
public sealed record DeleteStockTypeByIdCommand(
    int Id) : IRequest;
