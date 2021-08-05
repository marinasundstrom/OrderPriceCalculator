# Order Price Calculator

This is an implementation of a re-usable set of operations and calculations on Order-like entities.

## Contents

This project provides interfaces and extension methods that operate on the following artifcats:

* Orders
* Order Items
* Discounts

Making it easy to re-use the operations for functionality that deals with invoices.

## Sample


```c#
using System;
using System.Collections.Generic;
using System.Linq;

// Define your order and discounts

var order = new Order();
order.Items.Add(new OrderItem()
{
    Description = "Shirt",
    Price = 150m,
    VatRate = 0.25,
    Quantity = 3,
    Discounts = new List<Discount>() {
        new Discount {
            Description = "3 for 2",
            Amount = -150
        }
    }
});

order.Items.Add(new OrderItem()
{
    Description = "Coffee",
    Price = 24m,
    VatRate = 0.12,
    Quantity = 1
});

// Will update the calculated state
order.Update();

// "Total" has been update by the "Update" method
Console.WriteLine(order.Total);

// Now you can persist the entity in a DB using, for instance, EF Core.
```

Note: Swedish General VAT is 25% for most goods and services. 12% for food, drinks, and such.

## Layers

The library can be seen as consisting of 2 levels, or layers.

### Layer 1

Adds interfaces with the necessary properties and operations for performing calculations; Price, Quantity etc.

### Layer 2

Extens Layer 1 with interfaces containing properties and methods for persisting the results of the calculations; SubTotal, Total etc.

The ```Update``` methods.

## How to use

As long as your entity classes extend the interfaces you should be able to call the operations to calculate values and update the entities.