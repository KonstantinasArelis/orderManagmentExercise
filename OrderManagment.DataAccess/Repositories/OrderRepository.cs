using Microsoft.EntityFrameworkCore;
using OrderManagment.DataAccess.Context;
using OrderManagment.DataAccess.Entities;
using OrderManagment.DataAccess.Interfaces;

namespace OrderManagment.DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderManagmentDbContext context;

    public OrderRepository(OrderManagmentDbContext context)
    {
        this.context = context;
    }

    public OrderEntity SaveOrder(OrderEntity order)
    {
        context.Orders.Add(order);
        context.SaveChanges();

        return context.Orders
            .Include(o => o.Items)
                .ThenInclude(item => item.Product)
            .SingleOrDefault(o => o.Id == order.Id) ?? throw new InvalidOperationException("Failed to fetch the created order from DB");
    }

    public ICollection<OrderEntity> RetrieveAllOrders()
    {
        return context.Orders
            .Include(o => o.Items)
                .ThenInclude(item => item.Product)
            .ToList();
    }

    public ICollection<OrderEntity> RetrieveOrdersWithProduct(ProductEntity product)
    {
        throw new NotImplementedException();
    }

    public OrderEntity? RetrieveOrder(int orderId)
    {
        return context.Orders
            .Where(o => o.Id == orderId)
            .Include(o => o.Items)
                .ThenInclude(item => item.Product)
            .FirstOrDefault();
    }
}