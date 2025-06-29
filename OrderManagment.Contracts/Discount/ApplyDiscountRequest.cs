using System.ComponentModel.DataAnnotations;

namespace OrderManagment.Contracts.Discount;

public class ApplyDiscountRequest
{
    [Required]
    [Range(0, 100)]
    public decimal DiscountPercentage { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int DiscountMinimumProductCount { get; set; }
}