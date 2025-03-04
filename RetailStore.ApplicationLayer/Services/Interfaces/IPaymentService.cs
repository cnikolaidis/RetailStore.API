using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDto>> GetPayments();
        Task<PaymentDto?> GetPaymentById(int id);
        Task<PaymentDto> CreatePayment(PaymentDto dto);
        Task<bool> UpdatePayment(PaymentDto dto);
        Task<bool> DeletePayment(int id);
    }
}
