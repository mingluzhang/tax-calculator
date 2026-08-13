namespace TaxCalculator.Tests;

public class TaxBracketsTests
{
    private readonly TaxBrackets _brackets;

    public TaxBracketsTests()
    {
        _brackets = new TaxBrackets(new List<TaxBracket>
        {
            new(20000m, 0m),
            new(40000m, 0.10m),
            new(80000m, 0.20m),
            new(180000m, 0.30m),
            new(decimal.MaxValue, 0.40m),
        });
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(20000, 0)]
    [InlineData(40000, 2000)]
    [InlineData(60000, 6000)]
    [InlineData(80000, 10000)]
    [InlineData(180000, 40000)]
    [InlineData(200000, 48000)]
    public void CalculateAnnualTax_ReturnsCorrectSteppedTax(decimal salary, decimal expectedAnnualTax)
    {
        decimal tax = _brackets.CalculateAnnualTax(salary);
        Assert.Equal(expectedAnnualTax, tax);
    }

    [Theory]
    [InlineData(30000, 83.33)]
    [InlineData(50000, 333.33)]
    [InlineData(100000, 1333.33)]
    public void CalculateMonthlyTax_HandlesNonDivisibleTax(decimal salary, decimal expectedMonthlyTaxRounded)
    {
        decimal monthlyTax = _brackets.CalculateMonthlyTax(salary);
        Assert.Equal(expectedMonthlyTaxRounded, monthlyTax, 2);
    }
}