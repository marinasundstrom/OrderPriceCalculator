namespace OrderPriceCalculator.Tests;

using System.Collections.Generic;
using System.Linq;
using Xunit;

public class VatExtTest
{
    [Fact]
    public void GetVat25PercentFor100()
    {
        var result = VatExt.Vat(100m, 0.25);

        Assert.Equal(25m, result);
    }

    [Fact]
    public void AddVat25PercentTo100()
    {
        var result = VatExt.AddVat(100m, 0.25);

        Assert.Equal(125m, result);
    }

    [Fact]
    public void SubtractVat25PercentVatFrom125()
    {
        var result = VatExt.SubtractVat(125m, 0.25);

        Assert.Equal(100m, result);
    }

    [Fact]
    public void GetVat25PercentIncludedIn125()
    {
        var result = VatExt.GetVatIncl(125m, 0.25);

        Assert.Equal(25m, result);
    }
}
