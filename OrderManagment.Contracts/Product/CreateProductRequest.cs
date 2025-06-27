namespace OrderManagment.Contracts.Product;

public class CreateProductRequest
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}