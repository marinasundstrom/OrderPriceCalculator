namespace OrderPriceCalculator.Tests;

using Xunit;
using Shouldly;

public class TestScenarios
{
    [Fact]
    public void ApplySwedishPantOnBeverageContainer()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Coca Cola Zero Flaska 0,5 l",
            Price = 12.90m,
            VatRate = 0.12,
            Quantity = 1,
            Charges = new List<OrderCharge>() {
                new OrderCharge {
                    Description = "Pant",
                    Amount = 2
                },
            }
        });

        order.Update();

        order.Vat.ShouldBe(order.Items.Sum(x => x.Vat()));
        (order.Total - order.Rounding).ShouldBe(order.Items.Sum(x => x.Total));

        order.Totals.ShouldBeEmpty();

        order.Charge.ShouldBeNull();
        order.ChargeTotal.ShouldBe(2);

        order.Discount.ShouldBeNull();
        order.DiscountTotal.ShouldBeNull();
    }

    [Fact]
    public void Apply5PercentTip()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Kebabtallrik",
            Price = 69.00m,
            VatRate = 0.12,
            Quantity = 1
        });
        order.Items.Add(new OrderItem()
        {
            Description = "Coca Cola Zero",
            Price = 15.00m,
            VatRate = 0.12,
            Quantity = 1
        });

        order.Charges.Add(
            new OrderCharge
            {
                Description = "Tip",
                Percent = 0.15
            }
        );

        order.Update();

        order.Vat.ShouldBe(order.Items.Sum(x => x.Vat()));
        (order.Total - order.Rounding).ShouldBe(order.Items.Sum(x => x.Total)  + order.Charge);

        order.Totals.ShouldBeEmpty();

        order.Charge.ShouldNotBeNull();
        order.ChargeTotal.ShouldNotBeNull();

        order.Discount.ShouldBeNull();
        order.DiscountTotal.ShouldBeNull();
    }


    [Fact]
    public void ApplyAmount10DiscountOnSale()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Kebabtallrik",
            Price = 69.00m,
            VatRate = 0.12,
            Quantity = 1
        });
        order.Items.Add(new OrderItem()
        {
            Description = "Coca Cola Zero",
            Price = 15.00m,
            VatRate = 0.12,
            Quantity = 1
        });

        order.Discounts.Add(
            new OrderDiscount
            {
                Description = "Discount",
                Amount = -5m
            }
        );

        order.Update();

        order.Vat.ShouldBe(order.Items.Sum(x => x.Vat()));
        order.Total.ShouldBe(order.Items.Sum(x => x.Total) + order.Discount.GetValueOrDefault());

        order.Totals.ShouldBeEmpty();

        order.Charge.ShouldBeNull();
        order.ChargeTotal.ShouldBeNull();

        order.Discount.ShouldNotBeNull();
        order.DiscountTotal.ShouldNotBeNull();
    }

    [Fact]
    public void Test()
    {
        var order = new Order();
        order.Items.Add(new OrderItem()
        {
            Description = "Item 1",
            Price = 69.00m,
            VatRate = 0.12,
            Quantity = 3
        });
        order.Items.Add(new OrderItem()
        {
            Description = "Item 2",
            Price = 150.00m,
            VatRate = 0.25,
            Quantity = 2
        });

        order.Update();

        order.Vat.ShouldBe(order.Items.Sum(x => x.Vat()));
        order.Total.ShouldBe(order.Items.Sum(x => x.Total));

        order.SubTotal.ShouldBe(order.Totals.Sum(x => x.SubTotal));
        order.Vat.ShouldBe(order.Totals.Sum(x => x.Vat));
        order.Total.ShouldBe(order.Totals.Sum(x => x.Total));

        order.Charge.ShouldBeNull();

        order.Discount.ShouldBeNull();
        order.DiscountTotal.ShouldBeNull();
    }
}