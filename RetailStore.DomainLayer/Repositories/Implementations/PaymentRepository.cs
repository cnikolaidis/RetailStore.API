using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class PaymentRepository(RetailStoreDbContext dbContext) : IPaymentRepository
    {
        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await dbContext.Payments.ToListAsync();
        }

        public async Task<Payment?> GetPaymentById(int id)
        {
            return await dbContext.Payments.FindAsync(id);
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            payment.DateCreated = DateTime.Now;
            await dbContext.Payments.AddAsync(payment);
            await dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            var existingPayment = await dbContext.Payments.FindAsync(payment.OrderId);
            if (existingPayment == null)
                return false;

            existingPayment.OrderId = payment.OrderId;
            existingPayment.PaymentMethodId = payment.PaymentMethodId;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePayment(int id)
        {
            var existingPayment = await dbContext.Payments.FindAsync(id);
            if (existingPayment == null)
                return false;

            dbContext.Payments.Remove(existingPayment);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
