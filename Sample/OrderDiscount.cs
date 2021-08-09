namespace OrderPriceCalculator.Sample;

using System.Collections.Generic;

public class OrderDiscount : IDiscountWithTotal
{
    public string Description { get; set; } = null!;

    public Guid? DiscountId { get; set; }

    public decimal? Amount { get; set; }

    public double? Percent { get; set; }

    public decimal Total { get; set; }
}