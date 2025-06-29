namespace OrderManagment.Contracts.Report;

public class ProductDiscountReportResponse
{
    public required string Name { get; set; }
    public required decimal Discount { get; set; }
    public required int NumberOfOrders { get; set; }
    public required decimal TotalAmountWithoutDiscount { get; set; }
    public required decimal TotalAmountWithDiscount { get; set; }
}