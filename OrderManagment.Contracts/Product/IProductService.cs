using OrderManagment.Contracts.Product;
using OrderManagment.Contracts.Discount;
using System.Collections.ObjectModel;

namespace OrderManagment.BusinessLogic.Interfaces;

public interface IProductService
{
    public CreateProductResponse CreateProduct(CreateProductRequest request);
    public ICollection<RetrieveProductResponse> GetProducts(String productName);
    public void ApplyDiscountRequest(ApplyDiscountRequest request);
}