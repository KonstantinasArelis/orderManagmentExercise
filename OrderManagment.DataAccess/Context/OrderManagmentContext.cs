using Microsoft.EntityFrameworkCore;
using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Context;

public class OrderManagmentDbContext : DbContext
{
    public OrderManagmentDbContext(DbContextOptions<OrderManagmentDbContext> options) : base(options)
    {
    }
    
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}