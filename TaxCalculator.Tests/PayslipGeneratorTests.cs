namespace TaxCalculator.Tests;

public class PayslipGeneratorTests
{
    private readonly PayslipGenerator _generator;

    public PayslipGeneratorTests()
    {
        var calculator = new TaxCalculator(ExampleTaxBrackets.Brackets());
        _generator = new PayslipGenerator(calculator);
    }

    [Fact]
    public void Generate_WithExampleEmployee()
    {
        var employee = new Employee("Mary Song", new Money(60000m, Currency.NZD));
        Payslip payslip = _generator.Generate(employee);

        Assert.Equal("Mary Song", payslip.Name);
        Assert.Equal(new Money(5000m, Currency.NZD), payslip.GrossMonthlyIncome);
        Assert.Equal(new Money(500m, Currency.NZD), payslip.MonthlyIncomeTax);
        Assert.Equal(new Money(4500m, Currency.NZD), payslip.NetMonthlyIncome);
    }

    [Fact]
    public void Generate_WithNullEmployee_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _generator.Generate(null!));
    }
}