namespace OrderManagment.Contracts.Discount;

public class ApplyDiscountRequest
{
    public decimal? DiscountPercetage { get; set; }
    public int? DiscountMinimumProductCount { get; set; }
}