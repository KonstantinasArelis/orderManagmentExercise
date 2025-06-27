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

    public ProductEntity SaveProduct(ProductEntity product)
    {
        context.Products.Add(product);
        context.SaveChanges();

        return product;
    }

    public IReadOnlyCollection<ProductEntity> RetrieveProducts(String productName)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyCollection<ProductEntity> RetrieveDiscountedProducts()
    {
        throw new NotImplementedException();
    }
}