using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class PaymentMethodService(IPaymentMethodRepository repo, IMapper mapper) : IPaymentMethodService
    {
        public async Task<IEnumerable<PaymentMethodDto>> GetPaymentMethods()
        {
            var PaymentMethods = await repo.GetPaymentMethods();
            return PaymentMethods.Select(x => mapper.Map<PaymentMethodDto>(x));
        }

        public async Task<PaymentMethodDto?> GetPaymentMethodById(int id)
        {
            var PaymentMethod = await repo.GetPaymentMethodById(id);
            return mapper.Map<PaymentMethodDto>(PaymentMethod);
        }

        public async Task<PaymentMethodDto> CreatePaymentMethod(PaymentMethodDto dto)
        {
            var PaymentMethod = mapper.Map<PaymentMethodDto, PaymentMethod>(dto);
            var PaymentMethodEntity = await repo.CreatePaymentMethod(PaymentMethod);
            return mapper.Map<PaymentMethod, PaymentMethodDto>(PaymentMethodEntity);
        }

        public async Task<bool> UpdatePaymentMethod(PaymentMethodDto dto)
        {
            var p = mapper.Map<PaymentMethod>(dto);
            return await repo.UpdatePaymentMethod(p);
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            return await repo.DeletePaymentMethod(id);
        }
    }
}
