using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Interfaces;

public interface IOrderRepository
{
    public OrderEntity SaveOrder(OrderEntity order);
    public ICollection<OrderEntity> RetrieveAllOrders();
    public ICollection<OrderEntity> RetrieveOrdersWithProduct(ProductEntity product);
    public OrderEntity RetrieveOrder(int orderId);
}