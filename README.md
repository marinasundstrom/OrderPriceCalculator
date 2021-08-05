# Order Price Calculator

This is an implementation of a re-usable set of operations and calculations on Order-like entities.

## Contents

This project provides interfaces and extension methods that operate on the following artifcats:

* Orders
* Order Items
* Discounts

Making it easy to re-use the operations for functionality that deals with invoices.

## Layers

The library can be seen as consisting of 2 levels, or layers.

### Layer 1

Adds interfaces with the necessary properties and operations for performing calculations; Price, Quantity etc.

### Layer 2

Extens Layer 1 with interfaces containing properties and methods for persisting the results of the calculations; SubTotal, Total etc.

The ```Update``` methods.

## How to use

As long as your entity classes extend the interfaces you should be able to call the operations to calculate values and update the entities.