using OrderManagment.DataAccess.Entities;

namespace OrderManagment.DataAccess.Interfaces;

public interface IProductRepository
{
    public ProductEntity SaveProduct(ProductEntity product);
    public ICollection<ProductEntity> RetrieveProducts(String productName);
    public ICollection<ProductEntity> RetrieveDiscountedProducts();
}