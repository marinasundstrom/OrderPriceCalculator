namespace OrderPriceCalculator.Tests;

using System.Collections.Generic;
using System.Linq;
using Xunit;

public class OrderTest
{
    [Fact]
    public void Test1()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 3
        });

        order.Update();

        Assert.Empty(order.Totals);

        Assert.Equal(90m, order.Vat());
        Assert.Equal(450m, order.Total());
    }

    [Fact]
    public void Test2()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 3,
            Discounts = new List<Discount>() {
                new Discount {
                    Description = "3 for 2",
                    Amount = -150
                }
            }
        });

        order.Update();

        Assert.Empty(order.Totals);

        Assert.Equal(60m, order.Vat());
        Assert.Equal(300m, order.Total());
    }

    [Fact]
    public void Test3()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 3,
            Discounts = new List<Discount>() {
                new Discount {
                    Description = "3 for 2",
                    Amount = -150
                }
            }
        });
        order.Items.Add(new OrderItem()
        {
            Description = "Kaffe",
            Price = 24m,
            VatRate = 0.12,
            Quantity = 1
        });

        order.Update();

        Assert.Equal(324m, order.Total());

        Assert.Equal(2, order.Totals.Count());
    }
}
