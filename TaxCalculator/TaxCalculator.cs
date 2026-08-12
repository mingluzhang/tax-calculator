namespace TaxCalculator;

public class TaxCalculator
{
    public decimal GetMonthlyIncome(decimal salary)
    {
        return salary / 12m;
    }

    public decimal GetMonthlyIncomeTax(decimal salary)
    {
        return 0m;
    }

    public decimal GetNetMonthlyIncome(decimal salary)
    {
        return GetMonthlyIncome(salary) - GetMonthlyIncomeTax(salary);
    }
}
