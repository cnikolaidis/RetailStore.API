using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetOrderItems();
        Task<OrderItemDto?> GetOrderItemById(int id);
        Task<OrderItemDto> CreateOrderItem(OrderItemDto dto);
        Task<bool> UpdateOrderItem(OrderItemDto dto);
        Task<bool> DeleteOrderItem(int id);
    }
}
