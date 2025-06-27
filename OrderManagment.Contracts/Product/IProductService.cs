using OrderManagment.Contracts.Product;
using OrderManagment.Contracts.Discount;

namespace OrderManagment.BusinessLogic.Interfaces;

public interface IProductService
{
    public CreateProductResponse CreateProduct(CreateProductRequest request);
    public List<RetrieveProductResponse> GetProducts(RetrieveProductsRequest request);
    public void ApplyDiscountRequest(ApplyDiscountRequest request);
}