using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<OrderDto?> GetOrderById(int id);
        Task<OrderDto?> CreateOrder(OrderDto dto);
        Task<bool> UpdateOrder(OrderDto dto);
        Task<bool> DeleteOrder(int id);
    }
}
