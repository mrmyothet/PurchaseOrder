﻿namespace PurchaseOrder.Web.Models;

public class StockModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}
