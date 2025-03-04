using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IDeliveryDetailRepository
    {
        Task<IEnumerable<DeliveryDetail>> GetDeliveryDetails();
        Task<DeliveryDetail?> GetDeliveryDetailById(int id);
        Task<DeliveryDetail> CreateDeliveryDetail(DeliveryDetail dd);
        Task<bool> UpdateDeliveryDetail(DeliveryDetail dd);
        Task<bool> DeleteDeliveryDetail(int id);
    }
}
