namespace TaxCalculator;

public class TaxCalculator
{
    private static readonly TaxBrackets Brackets = new(new List<TaxBracket>
    {
        new(20000m, 0m),
        new(40000m, 0.10m),
        new(80000m, 0.20m),
        new(180000m, 0.30m),
        new(decimal.MaxValue, 0.40m),
    });

    public decimal GetMonthlyIncome(decimal salary)
    {
        return salary / 12m;
    }

    public decimal GetMonthlyIncomeTax(decimal salary)
    {
        return Brackets.CalculateMonthlyTax(salary);
    }

    public decimal GetNetMonthlyIncome(decimal salary)
    {
        return GetMonthlyIncome(salary) - GetMonthlyIncomeTax(salary);
    }
}
