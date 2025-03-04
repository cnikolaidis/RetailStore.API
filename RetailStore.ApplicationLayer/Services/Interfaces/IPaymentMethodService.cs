using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodDto>> GetPaymentMethods();
        Task<PaymentMethodDto?> GetPaymentMethodById(int id);
        Task<PaymentMethodDto> CreatePaymentMethod(PaymentMethodDto dto);
        Task<bool> UpdatePaymentMethod(PaymentMethodDto dto);
        Task<bool> DeletePaymentMethod(int id);
    }
}
