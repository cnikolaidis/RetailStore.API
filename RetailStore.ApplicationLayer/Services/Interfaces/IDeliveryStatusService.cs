using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IDeliveryStatusService
    {
        Task<IEnumerable<DeliveryStatusDto>> GetDeliveryStatuses();
        Task<DeliveryStatusDto?> GetDeliveryStatusById(int id);
        Task<DeliveryStatusDto> CreateDeliveryStatus(DeliveryStatusDto dto);
        Task<bool> UpdateDeliveryStatus(DeliveryStatusDto dto);
        Task<bool> DeleteDeliveryStatus(int id);
    }
}
