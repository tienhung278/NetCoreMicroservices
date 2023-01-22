using System.Net;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class CatalogController : ControllerBase
{
    private readonly IProductRepository _repository;

    public CatalogController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _repository.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id:length(24)}", Name = "GetProduct")]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await _repository.GetProduct(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet("[action]/{name}")]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByName(string name)
    {
        var products = await _repository.GetProductByName(name);
        return Ok(products);
    }
    
    [HttpGet("[action]/{category}")]
    [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByCategory(string category)
    {
        var products = await _repository.GetProductByCategory(category);
        return Ok(products);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        await _repository.CreateProduct(product);
        return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
    }

    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> UpdateProduct(Product product)
    {
        var result = await _repository.UpdateProduct(product);
        return !result ? StatusCode((int)HttpStatusCode.InternalServerError) : NoContent();
    }

    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var result = await _repository.DeleteProduct(id);
        return !result ? StatusCode((int)HttpStatusCode.InternalServerError) : NoContent();
    }
}