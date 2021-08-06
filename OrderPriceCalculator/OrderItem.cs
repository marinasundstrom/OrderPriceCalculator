using System.Collections.Generic;

public class OrderItem : IOrderItem2
{
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public double VatRate { get; set; }
    public double Quantity { get; set; }
    public decimal Total { get; set; }

    public List<Discount> Discounts { get; set; } = new List<Discount>();
    public decimal? Discount { get; set; }

    IEnumerable<IDiscount> IHasDiscounts.Discounts => Discounts;
    IEnumerable<IDiscountWithTotal> IHasDiscountsWithTotal.Discounts => Discounts;
}
