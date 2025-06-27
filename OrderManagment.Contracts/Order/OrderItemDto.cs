namespace OrderManagment.Contracts.Order;

public class OrderItemDto
{
    public required int ProductId { get; set; }
    public required int Quantity { get; set; }
}