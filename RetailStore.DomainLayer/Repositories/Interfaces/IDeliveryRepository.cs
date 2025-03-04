using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<IEnumerable<Delivery>> GetDeliveries();
        Task<Delivery?> GetDeliveryById(int id);
        Task<Delivery> CreateDelivery(Delivery d);
        Task<bool> UpdateDelivery(Delivery d);
        Task<bool> DeleteDelivery(int id);
    }
}
