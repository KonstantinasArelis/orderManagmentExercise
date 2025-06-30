using Microsoft.EntityFrameworkCore;
using OrderManagment.DataAccess.Context;
using OrderManagment.DataAccess.Entities;
using OrderManagment.DataAccess.Interfaces;

namespace OrderManagment.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly OrderManagmentDbContext context;

    public ProductRepository(OrderManagmentDbContext context)
    {
        this.context = context;
    }

    public async Task<ProductEntity> SaveProductAsync(ProductEntity product)
    {
        context.Products.Add(product);
        await context.SaveChangesAsync();

        return product;
    }

    public async Task<ICollection<ProductEntity>> RetrieveProductsAsync(string productName)
    {
        ICollection<ProductEntity> products = await context.Products
            .Where(p => p.Name.Contains(productName))
            .ToListAsync();

        return products;
    }

    public async Task<ProductEntity?> GetProductAsync(int id)
    {
        return await context.Products
            .Include(p => p.OrderItems)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdateProductAsync(ProductEntity product)
    {
        context.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task<ICollection<ProductEntity>> RetrieveDiscountedProductsAsync()
    {
        ICollection<ProductEntity> discountedProducts = await context.Products
            .Where(p => p.DiscountPercentage != null)
            .Include(p => p.OrderItems)
            .ToListAsync();

        return discountedProducts;
    }
}