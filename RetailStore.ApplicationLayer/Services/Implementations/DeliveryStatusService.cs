using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class DeliveryStatusService(IDeliveryStatusRepository repo, IMapper mapper) : IDeliveryStatusService
    {
        public async Task<IEnumerable<DeliveryStatusDto>> GetDeliveryStatuses()
        {
            var DeliveryStatuss = await repo.GetDeliveryStatuses();
            return DeliveryStatuss.Select(x => mapper.Map<DeliveryStatusDto>(x));
        }

        public async Task<DeliveryStatusDto?> GetDeliveryStatusById(int id)
        {
            var DeliveryStatus = await repo.GetDeliveryStatusById(id);
            return mapper.Map<DeliveryStatusDto>(DeliveryStatus);
        }

        public async Task<DeliveryStatusDto> CreateDeliveryStatus(DeliveryStatusDto dto)
        {
            var DeliveryStatus = mapper.Map<DeliveryStatusDto, DeliveryStatus>(dto);
            var DeliveryStatusEntity = await repo.CreateDeliveryStatus(DeliveryStatus);
            return mapper.Map<DeliveryStatus, DeliveryStatusDto>(DeliveryStatusEntity);
        }

        public async Task<bool> UpdateDeliveryStatus(DeliveryStatusDto dto)
        {
            var p = mapper.Map<DeliveryStatus>(dto);
            return await repo.UpdateDeliveryStatus(p);
        }

        public async Task<bool> DeleteDeliveryStatus(int id)
        {
            return await repo.DeleteDeliveryStatus(id);
        }
    }
}
