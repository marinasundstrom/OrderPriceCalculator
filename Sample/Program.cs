using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using OrderPriceCalculator;
using OrderPriceCalculator.Sample;

//var price = 100m.AddVat(0.25);
//var vat = price.GetVatIncl(0.25);
//var price2 = price.SubtractVat(0.25);

CultureInfo? culture = new("sv-SE");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

var order = new Order();
order.Items.Add(new OrderItem()
{
    Description = "Skjorta",
    Price = 150m,
    VatRate = 0.25,
    Quantity = 3,
    Discounts = new List<OrderDiscount>() {
        new OrderDiscount {
            Description = "3 for 2",
            Amount = -150
        }
    }
});
//order.Items.Add(new OrderItem()
//{
//    Description = "Skjorta",
//    Price = 150m,
//    VatRate = 0.25,
//    Quantity = 3,
//    Discounts = new List<Discount>() {
//        new Discount {
//            Description = "3 for 2",
//            Amount = -150
//        }
//    }
//});
//order.Items.Add(new OrderItem()
//{
//    Description = "Mjolk",
//    Price = 7.90m,
//    VatRate = 0.12,
//    Quantity = 1
//});
//order.Items.Add(new OrderItem()
//{
//    Description = "Kaffe",
//    Price = 24m,
//    VatRate = 0.12,
//    Quantity = 1
//});

//order.Discounts.Add(new Discount
//{
//    Description = "Discount",
//    Percent = -0.10
//});


order.Update();

order.Dump();