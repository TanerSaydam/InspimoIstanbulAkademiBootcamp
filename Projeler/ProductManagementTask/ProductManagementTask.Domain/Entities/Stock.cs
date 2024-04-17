using ProductManagementTask.Domain.Abstractions;
using ProductManagementTask.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementTask.Domain.Entities;
public sealed class Stock : Entity
{
    public StockClassEnum StockClass { get; set; } = StockClassEnum.Hammadde;

    [ForeignKey("StockType")]
    public int StockTypeId { get; set; }
    public StockType? StockType { get; set; }

    [ForeignKey("StockUnit")]
    public int StockUnitId { get; set; }
    public StockUnit? StockUnit { get; set; }
    
    public int Quantity { get; set; }
    public string ShelfInformation { get; set; } = string.Empty;
    public string CabinetInformation { get; set; } = string.Empty;
    public int CriticalQuantity { get; set; }
}
