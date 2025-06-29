using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.BusinessLogic.Service;
using OrderManagment.Contracts.Discount;
using OrderManagment.Contracts.Product;
using OrderManagment.Contracts.Report;

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

    [HttpGet("search/{name}")]
    public IActionResult SearchProducts([FromRoute] String name)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ICollection<RetrieveProductResponse> responses = productService.GetProducts(name);
        return Ok(responses);
    }

    [HttpPost("applyDiscount/{id}")]
    public IActionResult ApplyDiscount([FromRoute] int id, [FromBody] ApplyDiscountRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ApplyDiscountResponse response = productService.ApplyDiscount(id, request);
        return Ok(response);
    }

    [HttpGet("discountReport")]
    public IActionResult GetDiscountedProductReport()
    {
        ICollection<ProductDiscountReportResponse> responses = productService.GetProductDiscountReport();
        return Ok(responses);
    }

    [HttpGet("discountReport/{id}")]
    public IActionResult GetDiscountedProductReport([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ProductDiscountReportResponse response = productService.GetProductDiscountReport(id);
        return Ok(response);
    }
}