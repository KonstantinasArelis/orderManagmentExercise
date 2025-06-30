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

    public async Task<OrderEntity> SaveOrderAsync(OrderEntity order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();

        return await context.Orders
            .Include(o => o.Items)
                .ThenInclude(item => item.Product)
            .SingleOrDefaultAsync(o => o.Id == order.Id) ?? throw new InvalidOperationException("Failed to fetch the created order from DB");
    }

    public async Task<ICollection<OrderEntity>> RetrieveAllOrdersAsync()
    {
        return await context.Orders
            .Include(o => o.Items)
                .ThenInclude(item => item.Product)
            .ToListAsync();
    }

    public async Task<OrderEntity?> RetrieveOrderAsync(int orderId)
    {
        return await context.Orders
            .Where(o => o.Id == orderId)
            .Include(o => o.Items)
                .ThenInclude(item => item.Product)
            .FirstOrDefaultAsync();
    }
}