namespace TaxCalculator;

public class TaxCalculator
{
    private readonly TaxBrackets _brackets;

    public TaxCalculator(TaxBrackets brackets)
    {
        _brackets = brackets ?? throw new ArgumentNullException(nameof(brackets));
    }

    public decimal GetMonthlyIncome(decimal salary) => salary / 12m;

    public decimal GetMonthlyIncomeTax(decimal salary)
    {
        return _brackets.CalculateMonthlyTax(salary);
    }

    public decimal GetNetMonthlyIncome(decimal salary)
    {
        return GetMonthlyIncome(salary) - GetMonthlyIncomeTax(salary);
    }
}
