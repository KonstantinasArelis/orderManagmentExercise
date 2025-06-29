using Microsoft.AspNetCore.Mvc;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.BusinessLogic.Service;
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
    public IActionResult CreateOrder(CreateOrderRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        CreateOrderResponse response = orderService.CreateOrder(request);
        return CreatedAtAction(nameof(CreateOrder), new { Id = response.Id }, response);
    }

    [HttpGet]
    public IActionResult RetrieveAllOrders()
    {
        ICollection<RetrieveOrderResponse> responses = orderService.RetrieveOrders();

        return Ok(responses);
    }
}