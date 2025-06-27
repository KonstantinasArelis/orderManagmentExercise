using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.Contracts.Product;

namespace OrderManagment.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] CreateProductRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }

        CreateProductResponse response = productService.CreateProduct(request);
        return CreatedAtAction(nameof(CreateProduct), new { id = response.Id }, response);
    }
}