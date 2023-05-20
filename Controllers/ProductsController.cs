using Microsoft.AspNetCore.Mvc;
using dotNetCoreAPI.Models;

namespace dotNetCoreAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private static List<Product> Products = new List<Product>()
    {
        new Product() { ID = 1, Name = "Chicken", Unit = "Kilogram", Quantity = 45, Price = 80},
        new Product() { ID = 2, Name = "Shrimp", Unit = "Kilogram", Quantity = 15, Price = 350},
        new Product() { ID = 3, Name = "Meat", Unit = "Kilogram", Quantity = 25, Price = 250},
    };


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Products);
    }


    [HttpGet("{ID:int}")]
    public IActionResult Get(int ID)
    {
        var product = Products.FirstOrDefault(x => x.ID == ID);
        if (product == null) { return BadRequest("Invalid ID"); }
        return Ok(product);
    }


    [HttpPost]
    public IActionResult Post(Product Product)
    {
        Products.Add(Product);
        return CreatedAtAction("Get", Product.ID, Product);
    }


    [HttpPut("{ID:int}")]
    public IActionResult Put(int ID, Product newProduct)
    {
        var productIndex = Products.FindIndex(x => x.ID == ID);
        if (productIndex == -1) { return BadRequest("Invalid ID"); }
        Products[productIndex] = newProduct;
        return CreatedAtAction("Get", ID, newProduct);
    }


    [HttpDelete("{ID:int}")]
    public IActionResult Delete(int ID)
    {
        var product = Products.FirstOrDefault(x => x.ID == ID);
        if (product == null) { return BadRequest("Invalid ID"); }
        Products.Remove(product);
        return NoContent();
    }
}