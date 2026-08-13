using System.Globalization;

namespace TaxCalculator.Tests;

public class PayslipFormatterTests
{
    private readonly PayslipFormatter _formatter;

    public PayslipFormatterTests()
    {
        _formatter = new PayslipFormatter(CultureInfo.InvariantCulture);
    }

    [Fact]
    public void Format_WithExamplePayslip()
    {
        var payslip = new Payslip("Mary Song",
            new Money(5000m, Currency.NZD),
            new Money(500m, Currency.NZD),
            new Money(4500m, Currency.NZD));

        string result = Normalize(_formatter.Format(payslip));

        string expected = Normalize("""
            Monthly Payslip for: "Mary Song"
            Gross Monthly Income: $5000.00
            Monthly Income Tax: $500.00
            Net Monthly Income: $4500.00
            """);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Format_WithNonDivisibleAmounts_RoundsToTwoDecimals()
    {
        var payslip = new Payslip("Mary Song",
            new Money(8333.3333m, Currency.NZD),
            new Money(1333.3333m, Currency.NZD),
            new Money(7000m, Currency.NZD));

        string result = Normalize(_formatter.Format(payslip));

        string expected = Normalize("""
            Monthly Payslip for: "Mary Song"
            Gross Monthly Income: $8333.33
            Monthly Income Tax: $1333.33
            Net Monthly Income: $7000.00
            """);

        Assert.Equal(expected, result);
    }

    private static string Normalize(string text)
        => text.Replace("\r\n", "\n");
}