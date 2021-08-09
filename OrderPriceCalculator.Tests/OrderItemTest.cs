namespace OrderPriceCalculator.Tests;

using System;
using System.Collections.Generic;

using Xunit;

public class OrderItemTest
{
    [Fact]
    public void Test1()
    {
        var orderItem = new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 1
        };

        orderItem.Update();

        Assert.Equal(30m, orderItem.Vat());
        Assert.Equal(150m, orderItem.Total());
    }

    [Fact]
    public void Test2()
    {
        var orderItem = new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 2
        };

        orderItem.Update();

        Assert.Equal(60m, orderItem.Vat());
        Assert.Equal(300m, orderItem.Total());
    }

    [Fact]
    public void Test3()
    {
        var orderItem = new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 1,
            Discounts = new List<OrderDiscount>() {
                new OrderDiscount {
                    Description = "3 for 2",
                    Amount = -150
                }
            }
        };

        orderItem.Update();

        Assert.Equal(0m, orderItem.Vat());
        Assert.Equal(0m, orderItem.Total());
    }

    [Fact]
    public void Test4()
    {
        var orderItem = new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 2,
            Discounts = new List<OrderDiscount>() {
                new OrderDiscount {
                    Description = "3 for 2",
                    Amount = -150
                }
            }
        };

        orderItem.Update();

        Assert.Equal(30m, orderItem.Vat());
        Assert.Equal(150m, orderItem.Total());
    }

    [Fact]
    public void Test5()
    {
        var orderItem = new OrderItem()
        {
            Description = "Skjorta",
            Price = 150m,
            VatRate = 0.25,
            Quantity = 2,
            Discounts = new List<OrderDiscount>() {
                new OrderDiscount {
                    Description = "3 for 2",
                    Percent = -0.5
                }
            }
        };

        orderItem.Update();

        Assert.Equal(30m, orderItem.Vat());
        Assert.Equal(150m, orderItem.Total());
    }
}