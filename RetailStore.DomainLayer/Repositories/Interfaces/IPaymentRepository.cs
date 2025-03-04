using RetailStore.DomainLayer.Entities;

namespace RetailStore.DomainLayer.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPayments();
        Task<Payment?> GetPaymentById(int id);
        Task<Payment> CreatePayment(Payment p);
        Task<bool> UpdatePayment(Payment p);
        Task<bool> DeletePayment(int id);
    }
}
