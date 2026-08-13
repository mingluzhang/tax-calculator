namespace TaxCalculator.Tests;

public class MoneyTests
{
    [Fact]
    public void Subtract_WithSameCurrency_ReturnsDifference()
    {
        var gross = new Money(5000m, Currency.NZD);
        var tax = new Money(500m, Currency.NZD);
        var net = gross.Subtract(tax);
        Assert.Equal(new Money(4500m, Currency.NZD), net);
    }

    [Fact]
    public void Subtract_WithDifferentCurrency_ThrowsInvalidOperationException()
    {
        var aud = new Money(5000m, Currency.AUD);
        var nzd = new Money(500m, Currency.NZD);
        Assert.Throws<InvalidOperationException>(() => aud.Subtract(nzd));
    }

    [Theory]
    [InlineData(5000, "$5000.00")]
    [InlineData(8333.3333, "$8333.33")]
    [InlineData(0, "$0.00")]
    public void ToString_FormatsWithSymbolAndTwoDecimals(decimal amount, string expected)
    {
        var money = new Money(amount, Currency.NZD);
        Assert.Equal(expected, money.ToString());
    }
}