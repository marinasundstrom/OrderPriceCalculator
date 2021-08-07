namespace OrderPriceCalculator;

public class Discount : IDiscountWithTotal
{
    public string Description { get; set; } = null!;
    public decimal? Amount { get; set; }
    public double? Percent { get; set; }
    public decimal Total { get; set; }
}