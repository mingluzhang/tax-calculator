namespace TaxCalculator.Tests;

public class TaxCalculatorTests
{
    private readonly TaxCalculator _calculator;

    public TaxCalculatorTests()
    {
        _calculator = new TaxCalculator(DefaultTaxBrackets.Brackets());
    }
    
    [Fact]
    public void GetMonthlyIncome_WithExampleSalary()
    {
        Assert.Equal(5000m, _calculator.GetMonthlyIncome(60000m));
    }

    [Fact]
    public void GetMonthlyIncomeTax_WithExampleSalary()
    {
        Assert.Equal(500m, _calculator.GetMonthlyIncomeTax(60000m));
    }

    [Fact]
    public void GetNetMonthlyIncome_WithExampleSalary()
    {
        Assert.Equal(4500m, _calculator.GetNetMonthlyIncome(60000m));
    }
}