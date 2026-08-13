namespace TaxCalculator;

public record Payslip(
    string Name,
    Money GrossMonthlyIncome,
    Money MonthlyIncomeTax,
    Money NetMonthlyIncome
);