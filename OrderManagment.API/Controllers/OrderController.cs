using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.BusinessLogic.Service;
using OrderManagment.Contracts.Invoice;
using OrderManagment.Contracts.Order;

namespace OrderManagment.API.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;
    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync(CreateOrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid Order Model");
        }

        CreateOrderResponse response = await orderService.CreateOrderAsync(request);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> RetrieveAllOrders()
    {
        ICollection<RetrieveOrderResponse> responses = await orderService.RetrieveOrdersAsync();

        return Ok(responses);
    }
}