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
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(request);
        }

        CreateProductResponse response = await productService.CreateProductAsync(request);
        return Ok(response);
    }

    [HttpGet("search/{productName}")]
    public async Task<IActionResult> SearchProductsAsync([FromRoute] string productName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ICollection<RetrieveProductResponse> responses = await productService.GetProductsAsync(productName);
        return Ok(responses);
    }

    [HttpPost("applyDiscount/{productId}")]
    public async Task<IActionResult> ApplyDiscountAsync([FromRoute] int productId, [FromBody] ApplyDiscountRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ApplyDiscountResponse response = await productService.ApplyDiscountAsync(productId, request);
        return Ok(response);
    }
}