﻿namespace ProductProvider.Business.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }    
    public bool IsAvailable { get; set; }
    public int StockLevel { get; set; }

}
