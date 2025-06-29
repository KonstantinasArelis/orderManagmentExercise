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

    [HttpGet("{id}")]
    public IActionResult GetOrderInvoice([FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        OrderInvoiceResponse response = orderService.GetOrderInvoice(id);

        return Ok(response);
    }
}