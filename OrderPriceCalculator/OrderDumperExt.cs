namespace OrderPriceCalculator;

using static Console;

public static class OrderDumperExt
{
    public static void Dump(this IOrder2 order)
    {
        WriteLine($"{"Item",-20} {"Price",-20} {"Quantity",-12} {"Total",-12}");

        foreach (var item in order.Items)
        {
            WriteLine($"{item.Description,-20} {item.Price.ToString("c") + " (" + item.VatRate * 100 + "%)",-20} {item.Quantity + " pcs",-12} {(item.Total - item.Discount.GetValueOrDefault()).ToString("c"),-12}");

            foreach (var discount in item.Discounts)
            {
                WriteLine($"    {discount.Description,-15} {(discount.Percent is not null ? (item.VatRate * 100) + "%" : null),-12} {discount.Total.ToString("c"),33}");
            }

            WriteLine();
        }

        WriteLine();

        var totals = order.Totals();

        WriteLine($"{"VAT%",-5} {"Sub Total",-12} {"VAT",-12} {"Total",-12}");

        foreach (var f in totals)
        {
            WriteLine($"{f.VatRate * 100 + "%",-5} {f.SubTotal.ToString("c"),-12} {f.Vat.ToString("c"),-12} {f.Total.ToString("c"),-12}");
        }

        WriteLine();

        WriteLine($"Discount: {order.Discount?.ToString("c")}");
        WriteLine($"Vat: {order.Vat().ToString("c")}");
        WriteLine($"Rounding: {order.Rounding?.ToString("c")} ");
        WriteLine($"Total: {order.Total().ToString("c")}");
    }
}