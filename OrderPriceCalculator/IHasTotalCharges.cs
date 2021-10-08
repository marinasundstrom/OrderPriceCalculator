namespace OrderPriceCalculator;

public interface IHasTotalCharges : IHasCharges
{
    /// <summary>
    /// Gets or sets the total charged amount.
    /// </summary>
    decimal? TotalCharge { get; set; }
}