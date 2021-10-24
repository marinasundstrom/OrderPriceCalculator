namespace OrderPriceCalculator;

public interface IHasDiscountTotal : IHasDiscounts
{
    /// <summary>
    /// Gets or sets the total discounted amount.
    /// </summary>
    decimal? DiscountTotal { get; set; }
}