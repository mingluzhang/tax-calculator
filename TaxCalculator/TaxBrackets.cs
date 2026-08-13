namespace TaxCalculator;

public class TaxBrackets
{
    private readonly IReadOnlyList<TaxBracket> _brackets;

    public TaxBrackets(IReadOnlyList<TaxBracket> brackets)
    {
        _brackets = brackets;
    }

    public decimal CalculateAnnualTax(decimal salary)
    {
        decimal tax = 0m;
        decimal previousBound = 0m;

        foreach (var bracket in _brackets)
        {
            decimal taxable = Math.Min(salary, bracket.UpperBound) - previousBound;
            if (taxable <= 0)
            {
                break;
            }
                
            tax += taxable * bracket.Rate;
            previousBound = bracket.UpperBound;
        }

        return tax;
    }

    public decimal CalculateMonthlyTax(decimal salary)
    {
        return CalculateAnnualTax(salary) / 12m;
    }
}