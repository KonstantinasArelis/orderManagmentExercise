using System.Collections.ObjectModel;
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

    public ICollection<RetrieveOrderResponse> RetrieveOrders()
    {
        ICollection<OrderEntity> orderEntities = orderRepository.RetrieveAllOrders();
        ICollection<RetrieveOrderResponse> orderResponses = new Collection<RetrieveOrderResponse>();
        foreach (OrderEntity orderEntity in orderEntities)
        {
            orderResponses.Add(mapper.Map<RetrieveOrderResponse>(orderEntity));
        }
        return orderResponses;
    }

    public InvoiceDto GetOrderInvoice(int OrderId)
    {
        throw new NotImplementedException();
    }
}