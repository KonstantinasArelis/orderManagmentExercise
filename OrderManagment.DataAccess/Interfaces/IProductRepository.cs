using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Interfaces;

public interface IProductRepository
{
    public Task<ProductEntity> SaveProductAsync(ProductEntity product);
    public Task<ICollection<ProductEntity>> RetrieveProductsAsync(String productName);
    public Task<ICollection<ProductEntity>> RetrieveDiscountedProductsAsync();
    public Task<ProductEntity?> GetProductAsync(int id);
    public Task UpdateProductAsync(ProductEntity product);
}