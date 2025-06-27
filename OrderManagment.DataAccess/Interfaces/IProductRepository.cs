using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Interfaces;

public interface IProductRepository
{
    public ProductEntity SaveProduct(ProductEntity product);
    public IReadOnlyCollection<ProductEntity> RetrieveProducts(String productName);
    public IReadOnlyCollection<ProductEntity> RetrieveDiscountedProducts();
}