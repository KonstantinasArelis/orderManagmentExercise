namespace OrderManagment.Contracts.Invoice;

public class InvoiceOrderItemDto
{
    public required int Name { get; set; }
    public required int Quantity { get; set; }
    public required int Discount { get; set; }
    public required int MinimumDiscountAmount { get; set; }
}