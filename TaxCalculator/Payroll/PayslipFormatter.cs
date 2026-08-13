using System.Globalization;

namespace TaxCalculator;

public static class PayslipFormatter
{
    public static string Format(Payslip payslip)
    {
        return $"""
            Monthly Payslip for: "{payslip.Name}"
            Gross Monthly Income: {payslip.GrossMonthlyIncome}
            Monthly Income Tax: {payslip.MonthlyIncomeTax}
            Net Monthly Income: {payslip.NetMonthlyIncome}
            """;
    }
}