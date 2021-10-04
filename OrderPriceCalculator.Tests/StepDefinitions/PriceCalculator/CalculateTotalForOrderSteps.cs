using TechTalk.SpecFlow;
using Shouldly;

namespace OrderPriceCalculator.Tests.StepDefinitions.PriceCalculator;

[Scope(Scenario = "Calculate Total for Order")]
[Binding]
public class CalculateTotalForOrderSteps
{
    Order order = null!;

    [Given(@"the following Order Items")]
    public void GivenTheFollowingOrderItems(Table table) 
    {
        order = new Order();

        foreach(TableRow row in table.Rows)
        {
            var orderItem = new OrderItem();
            orderItem.Price = decimal.Parse(row["Price"]);
            orderItem.VatRate = double.Parse(row["VatRate"]);
            orderItem.Quantity = double.Parse(row["Quantity"]);

            order.Items.Add(orderItem);
        }
    }

    [Then(@"the SubTotal should be 103.04")]
    public void ThenTheSubTotalShouldBe()
    {
        order.SubTotal().ShouldBe(103.04m); 
    }

    [Then(@"the VAT should be 22.76")]
    public void ThenTheVatShouldBe()
    {
        order.Vat().ShouldBe(22.76m);
    }

    [Then(@"the Rounding should be 0.20")]
    public void ThenTheRoundingShouldBe()
    {
        order.Rounding().ShouldBe(0.20m);
    }

    [Then(@"the Total should be 126")]
    public void ThenTheTotalShouldBe() 
    {
        order.Total().ShouldBe(126m);
    }
}