namespace OrderManagment.Contracts.Order;

public class CreateOrderRequest
{
    public required List<CreateOrderItemRequest> Items { get; set; }
}