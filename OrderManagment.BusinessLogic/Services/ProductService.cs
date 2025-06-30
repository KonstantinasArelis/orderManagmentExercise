using System.Collections.ObjectModel;
using AutoMapper;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.Contracts.Discount;
using OrderManagment.Contracts.Product;
using OrderManagment.Contracts.Report;
using OrderManagment.DataAccess.Entities;
using OrderManagment.DataAccess.Interfaces;

namespace OrderManagment.BusinessLogic.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
    {
        ProductEntity newProduct = mapper.Map<ProductEntity>(request);
        ProductEntity createdProduct = await productRepository.SaveProductAsync(newProduct);
        return mapper.Map<CreateProductResponse>(createdProduct);
    }

    public async Task<ICollection<RetrieveProductResponse>> GetProductsAsync(String productName)
    {
        ICollection<ProductEntity> productEntities = await productRepository.RetrieveProductsAsync(productName);
        ICollection<RetrieveProductResponse> productResponses = new Collection<RetrieveProductResponse>();
        foreach (ProductEntity productEntity in productEntities)
        {
            productResponses.Add(mapper.Map<RetrieveProductResponse>(productEntity));
        }
        return productResponses;
    }

    public async Task<ApplyDiscountResponse> ApplyDiscountAsync(int productId, ApplyDiscountRequest request)
    {
        ProductEntity product = await productRepository.GetProductAsync(productId) ?? throw new KeyNotFoundException($"Product with id {productId} was not found");
        product.DiscountMinimumProductCount = request.DiscountMinimumProductCount;
        product.DiscountPercentage = request.DiscountPercentage;

        await productRepository.UpdateProductAsync(product);
        return mapper.Map<ApplyDiscountResponse>(await productRepository.GetProductAsync(productId));
    }

    public async Task<ICollection<ProductDiscountReportResponse>> GetProductDiscountReportAsync()
    {
        ICollection<ProductEntity> discountedProducts = await productRepository.RetrieveDiscountedProductsAsync();
        ICollection<ProductDiscountReportResponse> reports = new Collection<ProductDiscountReportResponse>();

        // Loop through all products and generate a report for each one
        foreach (ProductEntity productEntity in discountedProducts)
        {
            decimal TotalAmountWithoutDiscount = 0;
            decimal TotalAmountWithDiscount = 0;

            // Calculate the totals with and without discount
            foreach (OrderItemEntity orderItemEntity in productEntity.OrderItems)
            {
                TotalAmountWithoutDiscount += productEntity.Price * orderItemEntity.Quantity;
                TotalAmountWithDiscount += orderItemEntity.Quantity >= productEntity.DiscountMinimumProductCount
                    ? productEntity.Price * orderItemEntity.Quantity * (1 - productEntity.DiscountPercentage / 100 ?? throw new InvalidOperationException("Discounted product discount is null"))
                    : productEntity.Price * orderItemEntity.Quantity;
            }

            reports.Add(
                new ProductDiscountReportResponse()
                {
                    Name = productEntity.Name,
                    Discount = productEntity.DiscountPercentage ?? throw new InvalidOperationException("Discounted product discount is null"),
                    NumberOfOrders = productEntity.OrderItems.Count,
                    TotalAmountWithoutDiscount = TotalAmountWithoutDiscount,
                    TotalAmountWithDiscount = TotalAmountWithDiscount,
                }
            );
        }

        return reports;
    }

    public async Task<ProductDiscountReportResponse> GetProductDiscountReportAsync(int productId)
    {
        ProductEntity productEntity = await productRepository.GetProductAsync(productId) ?? throw new KeyNotFoundException($"Product with id {productId} was not found");
        decimal TotalAmountWithoutDiscount = 0;
        decimal TotalAmountWithDiscount = 0;

        // Calculate the totals with and without discount
        foreach (OrderItemEntity orderItemEntity in productEntity.OrderItems)
        {
            TotalAmountWithoutDiscount += productEntity.Price * orderItemEntity.Quantity;
            TotalAmountWithDiscount += orderItemEntity.Quantity >= productEntity.DiscountMinimumProductCount
                ? productEntity.Price * orderItemEntity.Quantity * (1 - productEntity.DiscountPercentage / 100 ?? throw new InvalidOperationException("Discounted product discount is null"))
                : productEntity.Price * orderItemEntity.Quantity;
        }

        // Generate report
        ProductDiscountReportResponse response = new ProductDiscountReportResponse()
        {
            Name = productEntity.Name,
            Discount = productEntity.DiscountPercentage ?? throw new InvalidOperationException("Discounted product discount is null"),
            NumberOfOrders = productEntity.OrderItems.Count,
            TotalAmountWithoutDiscount = TotalAmountWithoutDiscount,
            TotalAmountWithDiscount = TotalAmountWithDiscount,
        };

        return response;
    }
}