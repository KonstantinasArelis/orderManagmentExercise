namespace OrderManagment.Contracts.Discount;

public class ApplyDiscountResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public decimal? DiscountPercentage { get; set; }
    public int? DiscountMinimumProductCount { get; set; }
}