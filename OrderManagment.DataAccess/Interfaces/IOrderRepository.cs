using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Interfaces;

public interface IOrderRepository
{
    public Task<OrderEntity> SaveOrderAsync(OrderEntity order);
    public Task<ICollection<OrderEntity>> RetrieveAllOrdersAsync();
    public Task<OrderEntity> RetrieveOrderAsync(int orderId);
}