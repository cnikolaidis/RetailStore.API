using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IDeliveryStatusRepository
    {
        Task<IEnumerable<DeliveryStatus>> GetDeliveryStatuses();
        Task<DeliveryStatus?> GetDeliveryStatusById(int id);
        Task<DeliveryStatus> CreateDeliveryStatus(DeliveryStatus deliveryStatus);
        Task<bool> UpdateDeliveryStatus(DeliveryStatus deliveryStatus);
        Task<bool> DeleteDeliveryStatus(int id);
    }
}
