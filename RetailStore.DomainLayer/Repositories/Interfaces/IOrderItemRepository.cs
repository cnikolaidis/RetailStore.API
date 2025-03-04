using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetOrderItems();
        Task<OrderItem?> GetOrderItemById(int id);
        Task<OrderItem> CreateOrderItem(OrderItem oi);
        Task<bool> UpdateOrderItem(OrderItem oi);
        Task<bool> DeleteOrderItem(int id);
    }
}
