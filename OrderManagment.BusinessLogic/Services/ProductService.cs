using System.Collections.ObjectModel;
using AutoMapper;
using OrderManagment.Contracts.Discount;
using OrderManagment.Contracts.Product;
using OrderManagment.DataAccess.Entities;
using OrderManagment.DataAccess.Interfaces;

namespace OrderManagment.BusinessLogic.Interfaces;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public CreateProductResponse CreateProduct(CreateProductRequest request)
    {
        ProductEntity newProduct = mapper.Map<ProductEntity>(request);
        ProductEntity createdProduct = productRepository.SaveProduct(newProduct);
        return mapper.Map<CreateProductResponse>(createdProduct);
    }

    public ICollection<RetrieveProductResponse> GetProducts(String productName)
    {
        ICollection<ProductEntity> productEntities = productRepository.RetrieveProducts(productName);
        ICollection<RetrieveProductResponse> productResponses = new Collection<RetrieveProductResponse>();
        foreach (ProductEntity productEntity in productEntities)
        {
            productResponses.Add(mapper.Map<RetrieveProductResponse>(productEntity));
        }
        return productResponses;
    }

    public ApplyDiscountResponse ApplyDiscount(int productId, ApplyDiscountRequest request)
    {
        ProductEntity product = productRepository.GetProduct(productId) ?? throw new KeyNotFoundException();
        product.DiscountMinimumProductCount = request.DiscountMinimumProductCount;
        product.DiscountPercentage = request.DiscountPercentage;

        productRepository.UpdateProduct(product);
        return mapper.Map<ApplyDiscountResponse>(productRepository.GetProduct(productId));
    }
}