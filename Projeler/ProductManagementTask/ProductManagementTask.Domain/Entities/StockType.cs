using ProductManagementTask.Domain.Abstractions;

namespace ProductManagementTask.Domain.Entities;
public sealed class StockType : Entity
{
    public string Name { get; set; } = string.Empty;
}
