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

        decimal salary = employee.AnnualSalary;

        return new Payslip(
            employee.Name,
            _calculator.GetMonthlyIncome(salary),
            _calculator.GetMonthlyIncomeTax(salary),
            _calculator.GetNetMonthlyIncome(salary));
    }
}