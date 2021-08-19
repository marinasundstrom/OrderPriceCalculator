namespace OrderPriceCalculator;

public interface IHasCharges
{
    IEnumerable<ICharge> Charges { get; }

    decimal? Charge { get; set; }
}