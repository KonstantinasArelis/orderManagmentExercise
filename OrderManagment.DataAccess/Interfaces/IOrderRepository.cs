using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Interfaces;

public interface IOrderRepository
{
    public int SaveOrder(OrderEntity order);
    public IReadOnlyCollection<OrderEntity> RetrieveAllOrders();
    public IReadOnlyCollection<OrderEntity> RetrieveOrdersWithProduct(ProductEntity product);
    public OrderEntity RetrieveOrder(int orderId);
}