namespace OrderManagment.Contracts.Order;

public class CreateOrderRequest
{
    public required List<OrderItemDto> Items { get; set; }
}