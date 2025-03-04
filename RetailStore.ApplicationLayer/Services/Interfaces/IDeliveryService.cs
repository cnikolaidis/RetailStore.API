using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryDto>> GetDeliveries();
        Task<DeliveryDto?> GetDeliveryById(int id);
        Task<DeliveryDto> CreateDelivery(DeliveryDto dto);
        Task<bool> UpdateDelivery(DeliveryDto dto);
        Task<bool> DeleteDelivery(int id);
    }
}
