namespace OrderManagment.Contracts.Product;

public class CreateProductResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}