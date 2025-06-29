namespace OrderManagment.Contracts.Order;

public class CreateOrderItemResponse
{
    public required int ProductId { get; set; }

    public required string ProductName { get; set; }

    public required decimal ProductPrice { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public int? DiscountMinimumProductCount { get; set; }
    
    public required int Quantity { get; set; }
}