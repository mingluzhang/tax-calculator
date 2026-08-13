namespace TaxCalculator;

public record Payslip(
    string Name,
    decimal GrossMonthlyIncome,
    decimal MonthlyIncomeTax,
    decimal NetMonthlyIncome
);