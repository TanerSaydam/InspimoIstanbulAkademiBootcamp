using Ardalis.SmartEnum;

namespace ProductManagementTask.Domain.Enums;
public sealed class MoneyTypeEnum : SmartEnum<MoneyTypeEnum>
{
    public static readonly MoneyTypeEnum TL = new("TL", 1);
    public static readonly MoneyTypeEnum USD = new("USD", 2);
    public static readonly MoneyTypeEnum EUR = new("EURO", 3);
    public MoneyTypeEnum(string name, int value) : base(name, value)
    {
    }
}
