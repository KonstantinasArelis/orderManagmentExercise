using OrderManagment.Contracts.Invoice;
using OrderManagment.Contracts.Order;

namespace OrderManagment.BusinessLogic.Interfaces;


public interface IOrderService
{
    public CreateOrderResponse CreateOrder(CreateOrderRequest request);
    public ICollection<RetrieveOrderResponse> RetrieveOrders();
    public OrderInvoiceResponse GetOrderInvoice(int OrderId);
}