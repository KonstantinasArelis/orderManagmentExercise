namespace OrderManagment.Contracts.Order;

public class CreateOrderResponse
{
    public required int Id { get; set; }
    public required List<CreateOrderItemResponse> Items { get; set; }
}