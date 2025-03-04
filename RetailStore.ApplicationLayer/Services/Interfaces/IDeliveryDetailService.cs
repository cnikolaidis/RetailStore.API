using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IDeliveryDetailService
    {
        Task<IEnumerable<DeliveryDetailDto>> GetDeliveryDetails();
        Task<DeliveryDetailDto?> GetDeliveryDetailById(int id);
        Task<DeliveryDetailDto> CreateDeliveryDetail(DeliveryDetailDto dto);
        Task<bool> UpdateDeliveryDetail(DeliveryDetailDto dto);
        Task<bool> DeleteDeliveryDetail(int id);
    }
}
