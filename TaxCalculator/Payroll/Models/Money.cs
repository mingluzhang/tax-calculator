using System.Globalization;

namespace TaxCalculator;

public record Money(decimal Amount, Currency Currency)
{
    public Money Subtract(Money other)
    {
        ValidateSameCurrency(other);
        return this with { Amount = Amount - other.Amount };
    }

    public override string ToString()
    {
        return Symbol(Currency) + Amount.ToString("0.00", CultureInfo.InvariantCulture);
    }

    private void ValidateSameCurrency(Money other)
    {
        if (Currency != other.Currency)
            throw new InvalidOperationException(
                $"Cannot operate on different currencies: {Currency} and {other.Currency}.");
    }

    private static string Symbol(Currency currency) => currency switch
    {
        Currency.AUD => "$",
        Currency.NZD => "$",
        _ => throw new ArgumentOutOfRangeException(nameof(currency), currency, "Unknown currency.")
    };
}