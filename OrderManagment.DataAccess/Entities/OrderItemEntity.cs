using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagment.DataAccess.Entities;

public class OrderItemEntity
{
    [Key]
    public required int Id { get; set; }

    [Required]
    public required int FkOrderId { get; set; }

    [ForeignKey(nameof(FkOrderId))]
    public required OrderEntity Order { get; set; }

    [Required]
    public required int FkProductId { get; set; }

    [ForeignKey(nameof(FkProductId))]
    public required ProductEntity Product { get; set; }

    [Required]
    public required int Quantity { get; set; }
}