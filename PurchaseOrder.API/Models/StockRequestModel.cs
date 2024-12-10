﻿namespace PurchaseOrder.API.Models;

public class StockRequestModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}