using AutoMapper;
using OrderManagment.BusinessLogic.Interfaces;
using OrderManagment.Contracts.Invoice;
using OrderManagment.Contracts.Order;
using OrderManagment.DataAccess.Entities;
using OrderManagment.DataAccess.Interfaces;

namespace OrderManagment.BusinessLogic.Service;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IMapper mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }

    public CreateOrderResponse CreateOrder(CreateOrderRequest request)
    {
        OrderEntity order = mapper.Map<OrderEntity>(request);
        return mapper.Map<CreateOrderResponse>(orderRepository.SaveOrder(order));
    }

    public List<RetrieveOrderResponse> RetrieveOrders()
    {
        throw new NotImplementedException();
    }

    public InvoiceDto GetOrderInvoice(int OrderId)
    {
        throw new NotImplementedException();
    }
}