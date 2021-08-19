namespace OrderPriceCalculator;

public interface IChargeWithTotal : ICharge
{
    decimal Total { get; set; }
}