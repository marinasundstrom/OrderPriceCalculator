using TechTalk.SpecFlow;
using Shouldly;

namespace OrderPriceCalculator.Tests.StepDefinitions.PriceCalculator;

[Scope(Scenario = "Calculate Total for OrderItem")]
[Binding]
public class CalculateTotalForOrderItemSteps
{
    OrderItem orderItem = null!;

    [Given(@"that the Unit Price is (.*)")]
    public void GivenThatTheUnitPriceIs(decimal price) 
    {
        orderItem = new OrderItem();
        orderItem.Price = price;
    }

    [Given(@"the VAT Rate is (.*)")]
    public void GivenTheVatRateIs(double vatRate) 
    {
        orderItem.VatRate = vatRate;
    }

    [Given(@"the Quantity is (\d+)")]
    public void GivenTheQuantityIs(int quantity) 
    {
        orderItem.Quantity = quantity;
    }

    [Then(@"the SubTotal should be (.*)")]
    public void ThenTheSubTotalShouldBe(decimal subTotal)
    {
        orderItem.SubTotal().ShouldBe(subTotal);
    }

    [Then(@"the VAT should be (.*)")]
    public void ThenTheVatShouldBe(decimal vat)
    {
        orderItem.Vat().ShouldBe(vat);
    }

    [Then(@"the Total should be (.*)")]
    public void ThenTheTotalShouldBe(decimal total) 
    {
        orderItem.Total().ShouldBe(total);
    }
}