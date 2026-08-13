namespace TaxCalculator;

public class TaxBrackets
{
    private readonly IReadOnlyList<TaxBracket> _brackets;

    public TaxBrackets(IReadOnlyList<TaxBracket> brackets)
    {
        _brackets = Validated(brackets);
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

    private static IReadOnlyList<TaxBracket> Validated(IReadOnlyList<TaxBracket> brackets)
    {
        if (brackets is null)
            throw new ArgumentNullException(nameof(brackets));
        
        if (brackets.Count == 0)
            throw new ArgumentException("Tax brackets cannot be empty.", nameof(brackets));
        
        for (int i = 1; i < brackets.Count; i++)
            if (brackets[i].UpperBound <= brackets[i - 1].UpperBound)
                throw new ArgumentException("Tax brackets must be ascending by UpperBound.", nameof(brackets));

        return brackets;
    }
}