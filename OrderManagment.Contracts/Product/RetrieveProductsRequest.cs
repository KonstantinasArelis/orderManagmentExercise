using System.ComponentModel.DataAnnotations;

namespace OrderManagment.Contracts.Product;

public class RetrieveProductsRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; set; }
}