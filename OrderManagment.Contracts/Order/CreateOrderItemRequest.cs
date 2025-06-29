namespace OrderManagment.Contracts.Order;

public class CreateOrderItemRequest
{
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
}