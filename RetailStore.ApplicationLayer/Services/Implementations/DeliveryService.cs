using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class DeliveryService(IDeliveryRepository repo, IMapper mapper) : IDeliveryService
    {
        public async Task<IEnumerable<DeliveryDto>> GetDeliveries()
        {
            var Deliverys = await repo.GetDeliveries();
            return Deliverys.Select(x => mapper.Map<DeliveryDto>(x));
        }

        public async Task<DeliveryDto?> GetDeliveryById(int id)
        {
            var Delivery = await repo.GetDeliveryById(id);
            return mapper.Map<DeliveryDto>(Delivery);
        }

        public async Task<DeliveryDto> CreateDelivery(DeliveryDto dto)
        {
            var Delivery = mapper.Map<DeliveryDto, Delivery>(dto);
            var DeliveryEntity = await repo.CreateDelivery(Delivery);
            return mapper.Map<Delivery, DeliveryDto>(DeliveryEntity);
        }

        public async Task<bool> UpdateDelivery(DeliveryDto dto)
        {
            var p = mapper.Map<Delivery>(dto);
            return await repo.UpdateDelivery(p);
        }

        public async Task<bool> DeleteDelivery(int id)
        {
            return await repo.DeleteDelivery(id);
        }
    }
}
