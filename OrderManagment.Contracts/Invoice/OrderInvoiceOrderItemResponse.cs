using System.Text.Json.Serialization;

namespace OrderManagment.Contracts.Invoice;

public class OrderInvoiceOrderItemResponse
{
    public required string Name { get; set; }

    public required int Quantity { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public decimal? Discount { get; set; }

    public decimal Amount { get; set; }
}