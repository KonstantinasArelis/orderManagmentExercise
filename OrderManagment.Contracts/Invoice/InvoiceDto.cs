namespace OrderManagment.Contracts.Invoice;

public class InvoiceDto
{
    public required List<InvoiceOrderItemDto> items;
    public required decimal OrderAmount;
}