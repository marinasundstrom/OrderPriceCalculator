namespace OrderPriceCalculator.Tests;

using Xunit;

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

        /*
                Assert.Empty(order.Totals);

                Assert.Equal(60m, order.Vat());
                Assert.Equal(300m, order.Total());
                */
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

        /*
                Assert.Empty(order.Totals);

                Assert.Equal(60m, order.Vat());
                Assert.Equal(300m, order.Total());
                */
    }
}