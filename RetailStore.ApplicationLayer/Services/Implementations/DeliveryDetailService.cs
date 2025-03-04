using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class DeliveryDetailService(IDeliveryDetailRepository repo, IMapper mapper) : IDeliveryDetailService
    {
        public async Task<IEnumerable<DeliveryDetailDto>> GetDeliveryDetails()
        {
            var DeliveryDetails = await repo.GetDeliveryDetails();
            return DeliveryDetails.Select(x => mapper.Map<DeliveryDetailDto>(x));
        }

        public async Task<DeliveryDetailDto?> GetDeliveryDetailById(int id)
        {
            var DeliveryDetail = await repo.GetDeliveryDetailById(id);
            return mapper.Map<DeliveryDetailDto>(DeliveryDetail);
        }

        public async Task<DeliveryDetailDto> CreateDeliveryDetail(DeliveryDetailDto dto)
        {
            var DeliveryDetail = mapper.Map<DeliveryDetailDto, DeliveryDetail>(dto);
            var DeliveryDetailEntity = await repo.CreateDeliveryDetail(DeliveryDetail);
            return mapper.Map<DeliveryDetail, DeliveryDetailDto>(DeliveryDetailEntity);
        }

        public async Task<bool> UpdateDeliveryDetail(DeliveryDetailDto dto)
        {
            var p = mapper.Map<DeliveryDetail>(dto);
            return await repo.UpdateDeliveryDetail(p);
        }

        public async Task<bool> DeleteDeliveryDetail(int id)
        {
            return await repo.DeleteDeliveryDetail(id);
        }
    }
}
