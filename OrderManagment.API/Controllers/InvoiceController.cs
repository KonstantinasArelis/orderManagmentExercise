using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.Contracts.Invoice;

namespace OrderManagment.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IOrderService orderService;
    public InvoiceController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrderInvoiceAsync([FromRoute] int orderId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        OrderInvoiceResponse response = await orderService.GetOrderInvoiceAsync(orderId);
        
        return Ok(response);
    }
}