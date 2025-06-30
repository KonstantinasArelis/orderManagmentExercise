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

    public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
    {
        OrderEntity order = mapper.Map<OrderEntity>(request);
        return mapper.Map<CreateOrderResponse>(await orderRepository.SaveOrderAsync(order));
    }

    public async Task<ICollection<RetrieveOrderResponse>> RetrieveOrdersAsync()
    {
        ICollection<OrderEntity> orderEntities = await orderRepository.RetrieveAllOrdersAsync();
        ICollection<RetrieveOrderResponse> orderResponses = new Collection<RetrieveOrderResponse>();
        foreach (OrderEntity orderEntity in orderEntities)
        {
            orderResponses.Add(mapper.Map<RetrieveOrderResponse>(orderEntity));
        }
        return orderResponses;
    }

    public async Task<OrderInvoiceResponse> GetOrderInvoiceAsync(int OrderId)
    {
        OrderEntity orderEntity = await orderRepository.RetrieveOrderAsync(OrderId) ?? throw new KeyNotFoundException($"Order with id {OrderId} was not found");
        ICollection<OrderInvoiceOrderItemResponse> orderInvoiceOrderItemResponses = new Collection<OrderInvoiceOrderItemResponse>();
        decimal OrderAmount = 0;
        foreach (OrderItemEntity itemEntity in orderEntity.Items)
        {
            OrderInvoiceOrderItemResponse orderItemResponse = new OrderInvoiceOrderItemResponse()
            {
                Name = itemEntity.Product.Name,
                Quantity = itemEntity.Quantity,
                Amount = itemEntity.Quantity * itemEntity.Product.Price,
            };
            
            // Assign discount if needed
            if (itemEntity.Quantity >= itemEntity.Product.DiscountMinimumProductCount)
            {
                orderItemResponse.Discount = itemEntity.Product.DiscountPercentage ?? throw new InvalidOperationException("Discounted product discount is null");
            }

            // Calculate total, use discount if needed
            OrderAmount += (decimal)(orderItemResponse.Discount != null
                ? orderItemResponse.Amount * (1 - orderItemResponse.Discount / 100)
                : orderItemResponse.Amount);

            orderInvoiceOrderItemResponses.Add(orderItemResponse);
        }
        OrderInvoiceResponse response = new OrderInvoiceResponse()
        {
            Items = orderInvoiceOrderItemResponses,
            OrderAmount = OrderAmount,
        };

        return response;
    }
}