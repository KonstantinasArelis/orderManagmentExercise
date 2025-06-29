namespace OrderManagment.Contracts.Order;

public class RetrieveOrderResponse
{
    public required int Id { get; set; }
    public required List<CreateOrderItemResponse> Items { get; set; }
}