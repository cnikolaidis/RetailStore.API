using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;
using System;
using System.Security.Cryptography;
using System.Text;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class OrderService(
        IOrderRepository repo,
        IProductRepository productRepo,
        IPaymentRepository paymentRepo,
        IDeliveryRepository deliveryRepo,
        IMapper mapper) : IOrderService
    {
        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = await repo.GetOrders();
            return orders.Select(x => mapper.Map<OrderDto>(x));
        }

        public async Task<OrderDto?> GetOrderById(int id)
        {
            var order = await repo.GetOrderById(id);
            return mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto?> CreateOrder(OrderDto dto)
        {
            var productIds = dto.OrderItems.Select(oi => oi.ProductId);
            var products = await productRepo.GetProducts();
            var respectiveProducts = products.Where(p => productIds.Contains(p.Id));
            dto.OrderItems.ToList().ForEach(oi =>
            {
                oi.SubTotal = oi.Quantity * respectiveProducts.First(p => p.Id == oi.ProductId).Price;
                oi.DateCreated = DateTime.Now;
            });
            dto.TotalAmount = dto.OrderItems.Sum(oi => oi.SubTotal);
            dto.DateCreated = DateTime.Now;

            var order = mapper.Map<OrderDto, Order>(dto);
            var orderEntity = await repo.CreateOrder(order);

            var payment = new Payment
            {
                OrderId = orderEntity.Id,
                DateCreated = DateTime.Now,
                PaymentMethodId = 1
            };
            var paymentEntity = await paymentRepo.CreatePayment(payment);

            var delivery = new Delivery
            {
                OrderId = orderEntity.Id,
                TrackingNumber = GenerateTrackingNumber(DateTime.Now, orderEntity.Id).ToString(),
                DateCreated = DateTime.Now,
                DeliveryDetails = [ new DeliveryDetail { DeliveryStatusId = 1, DateCreated = DateTime.Now } ]
            };
            var deliveryEntity = await deliveryRepo.CreateDelivery(delivery);

            return await GetOrderById(orderEntity.Id);
        }

        public async Task<bool> UpdateOrder(OrderDto dto)
        {
            var order = mapper.Map<Order>(dto);
            return await repo.UpdateOrder(order);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await repo.DeleteOrder(id);
        }

        private Guid GenerateTrackingNumber(DateTime dt, int orderId)
        {
            var str = $"{dt:yyyyMMddHHmmssffff}_{orderId}";
            byte[] hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(str));
            return new Guid(hashBytes);
        }
    }
}
