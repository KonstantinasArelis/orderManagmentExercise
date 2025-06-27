namespace OrderManagment.Contracts.Order;

public class CreateOrderResponse
{
    public required List<OrderItemDto> Items { get; set; }
}