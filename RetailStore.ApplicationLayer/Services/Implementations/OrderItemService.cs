using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class OrderItemService(IOrderItemRepository repo, IMapper mapper) : IOrderItemService
    {
        public async Task<IEnumerable<OrderItemDto>> GetOrderItems()
        {
            var OrderItems = await repo.GetOrderItems();
            return OrderItems.Select(x => mapper.Map<OrderItemDto>(x));
        }

        public async Task<OrderItemDto?> GetOrderItemById(int id)
        {
            var OrderItem = await repo.GetOrderItemById(id);
            return mapper.Map<OrderItemDto>(OrderItem);
        }

        public async Task<OrderItemDto> CreateOrderItem(OrderItemDto dto)
        {
            var OrderItem = mapper.Map<OrderItemDto, OrderItem>(dto);
            var OrderItemEntity = await repo.CreateOrderItem(OrderItem);
            return mapper.Map<OrderItem, OrderItemDto>(OrderItemEntity);
        }

        public async Task<bool> UpdateOrderItem(OrderItemDto dto)
        {
            var p = mapper.Map<OrderItem>(dto);
            return await repo.UpdateOrderItem(p);
        }

        public async Task<bool> DeleteOrderItem(int id)
        {
            return await repo.DeleteOrderItem(id);
        }
    }
}
