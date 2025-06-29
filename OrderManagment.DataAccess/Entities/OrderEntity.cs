using System.ComponentModel.DataAnnotations;

namespace OrderManagment.DataAccess.Entities;

public class OrderEntity
{
    [Key]
    public required int Id { get; set; }

    public required ICollection<OrderItemEntity> Items { get; set; }
}