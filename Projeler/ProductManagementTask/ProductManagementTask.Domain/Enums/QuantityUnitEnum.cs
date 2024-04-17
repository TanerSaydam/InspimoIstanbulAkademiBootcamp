using Ardalis.SmartEnum;

namespace ProductManagementTask.Domain.Enums;
public sealed class QuantityUnitEnum : SmartEnum<QuantityUnitEnum>
{
    public static readonly QuantityUnitEnum Adet = new("Adet", 1);
    public static readonly QuantityUnitEnum m = new("m", 2);
    public static readonly QuantityUnitEnum m2 = new("m2", 3);
    public static readonly QuantityUnitEnum m3 = new("m2", 4);
    public static readonly QuantityUnitEnum g = new("g", 5);
    public static readonly QuantityUnitEnum KG = new("KG", 6);
    public static readonly QuantityUnitEnum Ton = new("Ton", 7);
    public QuantityUnitEnum(string name, int value) : base(name, value)
    {
    }
}
