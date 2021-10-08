namespace OrderPriceCalculator;

public interface IHasTotalDiscounts : IHasDiscounts
{
    /// <summary>
    /// Gets or sets the total discounted amount.
    /// </summary>
    decimal? TotalDiscount { get; set; }
}