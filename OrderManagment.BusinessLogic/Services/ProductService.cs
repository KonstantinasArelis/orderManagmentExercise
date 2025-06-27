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

    public List<RetrieveProductResponse> GetProducts(RetrieveProductsRequest request)
    {
        throw new NotImplementedException();
    }

    public void ApplyDiscountRequest(ApplyDiscountRequest request)
    {
        throw new NotImplementedException();
    }
}