namespace OrderPriceCalculator;

public interface IDiscountWithTotal : IDiscount
{
    /// <summary>
    /// Gets or sets the total discount.
    /// </summary>
    decimal Total { get; set; }
}