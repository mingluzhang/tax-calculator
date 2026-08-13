using System.Globalization;

namespace TaxCalculator;

public class PayslipFormatter
{
    private readonly CultureInfo _culture;

    public PayslipFormatter(CultureInfo? culture = null)
    {
        _culture = culture ?? CultureInfo.InvariantCulture;
    }

    public string Format(Payslip payslip)
    {
        return $"""
            Monthly Payslip for: "{payslip.Name}"
            Gross Monthly Income: {Money(payslip.GrossMonthlyIncome)}
            Monthly Income Tax: {Money(payslip.MonthlyIncomeTax)}
            Net Monthly Income: {Money(payslip.NetMonthlyIncome)}
            """;
    }

    private string Money(decimal amount)
    {
        return "$" + amount.ToString("0.00", _culture);
    }
}