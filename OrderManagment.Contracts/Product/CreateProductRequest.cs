using System.ComponentModel.DataAnnotations;

namespace OrderManagment.Contracts.Product;

public class CreateProductRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public required string Name { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public required decimal Price { get; set; }
}