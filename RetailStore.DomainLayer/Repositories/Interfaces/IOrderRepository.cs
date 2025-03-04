using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrderById(int id);
        Task<Order> CreateOrder(Order o);
        Task<bool> UpdateOrder(Order o);
        Task<bool> DeleteOrder(int id);
    }
}
