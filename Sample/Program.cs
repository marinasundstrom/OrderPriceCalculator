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
    Description = "Kebabtallrik",
    Price = 69.00m,
    VatRate = 0.12,
    Quantity = 1
});
order.Items.Add(new OrderItem()
{
    Description = "Coca Cola Zero",
    Price = 15.00m,
    VatRate = 0.12,
    Quantity = 1
});

order.Charges.Add(
    new OrderCharge
    {
        Description = "Tip",
        Percent = 0.15
    }
);

// var order = new Order();
// order.Items.Add(new OrderItem()
// {
//     Description = "Coca Cola Zero Flaska 0,5 l",
//     Price = 12.90m,
//     VatRate = 0.12,
//     Quantity = 1,
//     Charges = new List<OrderCharge>() {
//         new OrderCharge {
//             Description = "Pant",
//             Amount = 2
//         },
//     }
// });

// var order = new Order();
// order.Items.Add(new OrderItem()
// {
//     Description = "Skjorta",
//     Price = 150m,
//     VatRate = 0.25,
//     Quantity = 7,
//     Discounts = new List<OrderDiscount>() {
//         new OrderDiscount {
//             Description = "3 for 2",
//             Quantity = 3,
//             //Limit = 1,
//             Amount = -150
//         }
//     }
// });

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