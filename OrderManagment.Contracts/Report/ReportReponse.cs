namespace OrderManagment.Contracts.Report;

public class ReportResponse
{
    public required string Name { get; set; }
    public required decimal Discount { get; set; }
    public required int NumberOfOrders { get; set; }
    public required decimal TotalAmount { get; set; }
}