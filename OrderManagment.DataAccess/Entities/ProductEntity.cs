using System.ComponentModel.DataAnnotations;

namespace OrderManagment.DataAccess.Entities;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }
}