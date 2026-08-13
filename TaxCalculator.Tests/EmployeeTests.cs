namespace TaxCalculator.Tests;

public class EmployeeTests
{
    [Fact]
    public void Constructor_WithNegativeSalary_ThrowsArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Employee("Mary Song", new Money(-1m, Currency.NZD)));
    }
}