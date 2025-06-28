namespace OrderManagment.Contracts.Discount;

public class ApplyDiscountRequest
{
    public decimal? DiscountPercentage { get; set; }
    public int? DiscountMinimumProductCount { get; set; }
}