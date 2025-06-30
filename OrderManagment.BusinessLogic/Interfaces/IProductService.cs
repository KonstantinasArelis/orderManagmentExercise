using OrderManagment.Contracts.Product;
using OrderManagment.Contracts.Discount;
using System.Collections.ObjectModel;
using OrderManagment.Contracts.Report;

namespace OrderManagment.BusinessLogic.Interfaces;

public interface IProductService
{
    public Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);
    public Task<ICollection<RetrieveProductResponse>> GetProductsAsync(String productName);
    public Task<ApplyDiscountResponse> ApplyDiscountAsync(int productId, ApplyDiscountRequest request);
    public Task<ICollection<ProductDiscountReportResponse>> GetProductDiscountReportAsync();
    public Task<ProductDiscountReportResponse> GetProductDiscountReportAsync(int productId);
}