using System.ComponentModel.DataAnnotations;

namespace OrderManagment.Contracts.Discount;

public class ApplyDiscountRequest
{
    [Range(0, 100)]
    public decimal? DiscountPercentage { get; set; }
    [Range(1, int.MaxValue)]
    public int? DiscountMinimumProductCount { get; set; }
}