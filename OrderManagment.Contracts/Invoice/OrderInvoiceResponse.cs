namespace OrderManagment.Contracts.Invoice;

public class OrderInvoiceResponse
{
    public required ICollection<OrderInvoiceOrderItemResponse> Items { get; set; }
    public required decimal OrderAmount { get; set; }
}