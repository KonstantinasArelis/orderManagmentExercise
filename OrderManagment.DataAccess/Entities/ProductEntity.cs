using System.ComponentModel.DataAnnotations;

namespace OrderManagment.DataAccess.Entities;

public class ProductEntity
{
    [Key]
    public required int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required decimal Price { get; set; }
}