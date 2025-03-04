using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class PaymentService(IPaymentRepository repo, IMapper mapper) : IPaymentService
    {
        public async Task<IEnumerable<PaymentDto>> GetPayments()
        {
            var Payments = await repo.GetPayments();
            return Payments.Select(x => mapper.Map<PaymentDto>(x));
        }

        public async Task<PaymentDto?> GetPaymentById(int id)
        {
            var Payment = await repo.GetPaymentById(id);
            return mapper.Map<PaymentDto>(Payment);
        }

        public async Task<PaymentDto> CreatePayment(PaymentDto dto)
        {
            var Payment = mapper.Map<PaymentDto, Payment>(dto);
            var PaymentEntity = await repo.CreatePayment(Payment);
            return mapper.Map<Payment, PaymentDto>(PaymentEntity);
        }

        public async Task<bool> UpdatePayment(PaymentDto dto)
        {
            var p = mapper.Map<Payment>(dto);
            return await repo.UpdatePayment(p);
        }

        public async Task<bool> DeletePayment(int id)
        {
            return await repo.DeletePayment(id);
        }
    }
}
