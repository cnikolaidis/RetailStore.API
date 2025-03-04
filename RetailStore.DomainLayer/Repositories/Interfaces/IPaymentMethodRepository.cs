using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethod>> GetPaymentMethods();
        Task<PaymentMethod?> GetPaymentMethodById(int id);
        Task<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod);
        Task<bool> UpdatePaymentMethod(PaymentMethod paymentMethod);
        Task<bool> DeletePaymentMethod(int id);
    }
}
