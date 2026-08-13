namespace TaxCalculator;

public static class DefaultTaxBrackets
{
    public static TaxBrackets Brackets() => new(new List<TaxBracket>
    {
        new(20000m, 0m),
        new(40000m, 0.10m),
        new(80000m, 0.20m),
        new(180000m, 0.30m),
        new(decimal.MaxValue, 0.40m),
    });
}