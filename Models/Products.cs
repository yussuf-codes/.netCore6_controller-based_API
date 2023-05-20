namespace dotNetCoreAPI.Models;

public class Product
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Unit { get; set; }
    public int? Quantity { get; set; }
    public int? Price { get; set; }
}