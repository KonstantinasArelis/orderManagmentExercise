using System.ComponentModel.DataAnnotations;

namespace OrderManagment.Contracts.Order;

public class CreateOrderRequest
{
    [Required]
    public required List<CreateOrderItemRequest> Items { get; set; }
}