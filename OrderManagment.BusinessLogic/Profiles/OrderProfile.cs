using AutoMapper;
using OrderManagment.Contracts.Order;
using OrderManagment.DataAccess.Entities;

namespace OrderManagment.BusinessLogic.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderEntity, CreateOrderResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        CreateMap<CreateOrderRequest, OrderEntity>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        CreateMap<OrderItemEntity, CreateOrderItemResponse>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.FkProductId))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
            .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Product.DiscountPercentage))
            .ForMember(dest => dest.DiscountMinimumProductCount, opt => opt.MapFrom(src => src.Product.DiscountMinimumProductCount))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        CreateMap<CreateOrderItemRequest, OrderItemEntity>()
            .ForMember(dest => dest.FkProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
    }
}