using TechTalk.SpecFlow;
using Shouldly;

namespace OrderPriceCalculator.Tests.StepDefinitions.PriceCalculator;

[Scope(Scenario = "Apply Swedish Pant charge to beverage container")]
[Binding]
public class ApplySwedishPantChargeToBeverageContainerSteps
{
    OrderItem item = null!;

    [Given(@"that the Consumer has bought a beverage in a container")]
    public void GivenThatTheConsumerHasBoughtABeverageInAContainer()
    {
        item = new OrderItem()
        {
            Description = "Coca Cola Zero Flaska 0,5 l",
            Quantity = 1
        };
    }

    [Given(@"the Price is 12.90 and the VAT Rate is 12%")]
    public void GivenThePriceIsXAndTheVatRateIsZ() 
    {
        item.Price = 12.90m;
        item.VatRate = 0.12;
    }

    [Given(@"the Pant Charge is 2")]
    public void GivenThePantChargeIs() 
    {
        item.Charges = new List<OrderCharge>() {
            new OrderCharge {
                Description = "Pant",
                Amount = 2
            }
        };
    }

    [Then(@"the Total should be 14.90")]
    public void ThenTheTotalShouldBe()
    {
        item.Total().ShouldBe(14.90m); 
    }
}