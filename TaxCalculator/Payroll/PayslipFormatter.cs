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
            Gross Monthly Income: {payslip.GrossMonthlyIncome}
            Monthly Income Tax: {payslip.MonthlyIncomeTax}
            Net Monthly Income: {payslip.NetMonthlyIncome}
            """;
    }
}