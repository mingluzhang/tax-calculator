namespace TaxCalculator;

public class PayslipGenerator
{
    private readonly TaxCalculator _calculator;

    public PayslipGenerator(TaxCalculator calculator)
    {
        _calculator = calculator ?? throw new ArgumentNullException(nameof(calculator));
    }

    public Payslip Generate(Employee employee)
    {
        if (employee is null)
            throw new ArgumentNullException(nameof(employee));

        decimal salary = employee.AnnualSalary.Amount;
        Currency currency = employee.AnnualSalary.Currency;

        var gross = new Money(_calculator.GetMonthlyIncome(salary), currency);
        var tax = new Money(_calculator.GetMonthlyIncomeTax(salary), currency);
        var net = new Money(_calculator.GetNetMonthlyIncome(salary), currency);

        return new Payslip(employee.Name, gross, tax, net);
    }
}