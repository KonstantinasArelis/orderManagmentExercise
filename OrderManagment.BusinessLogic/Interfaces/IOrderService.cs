using OrderManagment.Contracts.Invoice;
using OrderManagment.Contracts.Order;

namespace OrderManagment.BusinessLogic.Interfaces;


public interface IOrderService
{
    public Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);
    public Task<ICollection<RetrieveOrderResponse>> RetrieveOrdersAsync();
    public Task<OrderInvoiceResponse> GetOrderInvoiceAsync(int OrderId);
}