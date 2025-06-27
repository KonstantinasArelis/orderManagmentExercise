namespace OrderManagment.Contracts.Product;

public class RetrieveProductResponse
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
}