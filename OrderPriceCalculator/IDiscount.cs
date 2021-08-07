namespace OrderPriceCalculator;

public interface IDiscount
{
    string Description { get; set; }

    decimal? Amount { get; set; }

    double? Percent { get; set; }
}
