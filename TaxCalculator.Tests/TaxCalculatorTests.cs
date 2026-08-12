namespace TaxCalculator.Tests;

public class TaxCalculatorTests
{
    [Fact]
    public void GetMonthlyIncome_WithExampleSalary()
    {
        var calculator = new TaxCalculator();
        Assert.Equal(5000m, calculator.GetMonthlyIncome(60000m));
    }

    [Fact]
    public void GetMonthlyIncomeTax_WithExampleSalary()
    {
        var calculator = new TaxCalculator();
        Assert.Equal(500m, calculator.GetMonthlyIncomeTax(60000m));
    }

    [Fact]
    public void GetNetMonthlyIncome_WithExampleSalary()
    {
        var calculator = new TaxCalculator();
        Assert.Equal(4500m, calculator.GetNetMonthlyIncome(60000m));
    }
}