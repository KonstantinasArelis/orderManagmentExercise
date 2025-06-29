using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.Contracts.Discount;
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

    [HttpGet("search/{productName}")]
    public IActionResult SearchProducts([FromRoute] string productName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ICollection<RetrieveProductResponse> responses = productService.GetProducts(productName);
        return Ok(responses);
    }

    [HttpPost("applyDiscount/{productId}")]
    public IActionResult ApplyDiscount([FromRoute] int productId, [FromBody] ApplyDiscountRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ApplyDiscountResponse response = productService.ApplyDiscount(productId, request);
        return Ok(response);
    }
}