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