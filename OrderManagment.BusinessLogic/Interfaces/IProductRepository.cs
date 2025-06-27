using OrderManagment.Contracts.Product;
using OrderManagment.DataAccess.Entities;

namespace OrderManagment.BusinessLogic.Interfaces;

public interface IProductRepository
{
    public int SaveProduct(ProductEntity product);
    public IReadOnlyCollection<ProductEntity> RetrieveProducts(RetrieveProductsRequest request);
    public IReadOnlyCollection<ProductEntity> RetrieveDiscountedProducts();
}