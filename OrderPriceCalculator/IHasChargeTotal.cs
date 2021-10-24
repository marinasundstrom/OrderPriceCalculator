namespace OrderPriceCalculator;

public interface IHasChargeTotal : IHasCharges
{
    /// <summary>
    /// Gets or sets the total charged amount.
    /// </summary>
    decimal? ChargeTotal { get; set; }
}