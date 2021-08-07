namespace OrderPriceCalculator.Tests;

using System.Collections.Generic;

public class Order : IOrder2WithTotals
{
    public int Id { get; set; }
    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public decimal? SubTotal { get; set; }
    public double? VatRate { get; set; }
    public decimal? Vat { get; set; }

    public decimal? Rounding { get; set; }
    public decimal Total { get; set; }

    public List<OrderTotals> Totals { get; set; } = new List<OrderTotals>();

    public List<Discount> Discounts { get; set; } = new List<Discount>();
    public decimal? Discount { get; set; }

    IEnumerable<IOrderItem> IOrder.Items => Items;
    IEnumerable<IOrderItem2> IOrder2.Items => Items;

    IEnumerable<IOrderTotals> IOrder2WithTotals.Totals => Totals;

    IEnumerable<IDiscount> IHasDiscounts.Discounts => Discounts;
    IEnumerable<IDiscountWithTotal> IHasDiscountsWithTotal.Discounts => Discounts;
}
