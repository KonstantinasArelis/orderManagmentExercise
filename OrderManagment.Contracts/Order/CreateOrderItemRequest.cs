using System.ComponentModel.DataAnnotations;

namespace OrderManagment.Contracts.Order;

public class CreateOrderItemRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public required int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public required int Quantity { get; set; }
}