using ProductManagementTask.Domain.Abstractions;
using ProductManagementTask.Domain.Enums;
using ProductManagementTask.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagementTask.Domain.Entities;
public sealed class StockUnit : Entity
{
    public string Code { get; set; } = string.Empty;

    [ForeignKey("StokType")]
    public int StockTypeId { get; set; }
    public StockType? StockType { get; set; }
    public QuantityUnitEnum QuantityUnit { get; set; } = QuantityUnitEnum.Adet;
    public string Description { get; set; } = string.Empty;
    public Money Buying { get; set; } = Money.Zero();
    public Money Selling { get; set; } = Money.Zero();
    public int PaperWeight { get; set; }
}