using System.Collections.Generic;

public class Order : IOrder2
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    public decimal? Rounding { get; set; }
    public decimal Total { get; set; }

    public List<Discount> Discounts { get; set; } = new List<Discount>();
    public decimal? Discount { get; set; }

    IEnumerable<IOrderItem> IOrder.Items => Items;
    IEnumerable<IOrderItem2> IOrder2.Items => Items;

    IEnumerable<IDiscount> IHasDiscounts.Discounts => Discounts;
    IEnumerable<IDiscountWithTotal> IHasDiscountsWithTotal.Discounts => Discounts;
}
