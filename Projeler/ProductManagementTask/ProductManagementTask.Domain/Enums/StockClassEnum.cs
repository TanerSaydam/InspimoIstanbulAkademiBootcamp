using Ardalis.SmartEnum;

namespace ProductManagementTask.Domain.Enums;
public sealed class StockClassEnum : SmartEnum<StockClassEnum>
{
    public static readonly StockClassEnum Hammadde = new("Hammadde", 1);
    public static readonly StockClassEnum YariMamul = new("Yarı Mamül", 2);
    public static readonly StockClassEnum Mamul = new("Mamül", 3);
    public StockClassEnum(string name, int value) : base(name, value)
    {
    } 
}
