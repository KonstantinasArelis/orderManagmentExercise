using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.Contracts.Report;

namespace OrderManagment.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class ReportController : ControllerBase
{
    private readonly IProductService productService;
    public ReportController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpGet("discountReport")]
    public async Task<IActionResult> GetDiscountedProductReportAsync()
    {
        ICollection<ProductDiscountReportResponse> responses = await productService.GetProductDiscountReportAsync();
        return Ok(responses);
    }

    [HttpGet("discountReport/{productId}")]
    public async Task<IActionResult> GetDiscountedProductReportAsync([FromRoute] int productId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ProductDiscountReportResponse response = await productService.GetProductDiscountReportAsync(productId);
        return Ok(response);
    }
}