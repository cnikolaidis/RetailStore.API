using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Mappings
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();

            CreateMap<PaymentMethod, PaymentMethodDto>();
            CreateMap<PaymentMethodDto, PaymentMethod>();

            CreateMap<Payment, PaymentDto>();
            CreateMap<PaymentDto, Payment>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<OrderItemDto, OrderItem>();

            CreateMap<Delivery, DeliveryDto>();
            CreateMap<DeliveryDto, Delivery>();

            CreateMap<DeliveryDetail, DeliveryDetailDto>();
            CreateMap<DeliveryDetailDto, DeliveryDetail>();

            CreateMap<DeliveryStatus, DeliveryStatusDto>();
            CreateMap<DeliveryStatusDto, DeliveryStatus>();
        }
    }
}
