namespace OrderPriceCalculator;

public interface IHasDiscounts
{
    IEnumerable<IDiscount> Discounts { get; }

    decimal? Discount { get; set; }
}