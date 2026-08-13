namespace TaxCalculator;

public record Employee
{
    public string Name { get; }
    public decimal AnnualSalary { get; }

    public Employee(string name, decimal annualSalary)
    {
        if (annualSalary < 0)
            throw new ArgumentOutOfRangeException(nameof(annualSalary),
                "Annual salary cannot be negative.");
        Name = name;
        AnnualSalary = annualSalary;
    }
}