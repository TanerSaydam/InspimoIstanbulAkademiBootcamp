using ProductManagementTask.Domain.Enums;

namespace ProductManagementTask.Domain.ValueObjects;
public sealed record Money(decimal Amount, MoneyTypeEnum Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if(a.Currency != b.Currency)
        {
            throw new ArgumentException("Para birimleri birbirinden farklı değerler toplanamaz!");
        }

        return new(a.Amount + b.Amount, a.Currency);
    }

    public static Money Zero() => new(0, MoneyTypeEnum.TL);
    public static Money Zero(MoneyTypeEnum currency) => new(0, currency);

    public bool IsZero() => this == Zero(Currency);
}