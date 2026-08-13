namespace TaxCalculator;

public record Employee
{
    public string Name { get; }
    public Money AnnualSalary { get; }

    public Employee(string name, Money annualSalary)
    {
        if (annualSalary.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(annualSalary),
                "Annual salary cannot be negative.");
        Name = name;
        AnnualSalary = annualSalary;
    }
}