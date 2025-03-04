using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class PaymentMethodRepository(RetailStoreDbContext dbContext) : IPaymentMethodRepository
    {
        public async Task<IEnumerable<PaymentMethod>> GetPaymentMethods()
        {
            return await dbContext.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod?> GetPaymentMethodById(int id)
        {
            return await dbContext.PaymentMethods.FindAsync(id);
        }

        public async Task<PaymentMethod> CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            await dbContext.PaymentMethods.AddAsync(paymentMethod);
            await dbContext.SaveChangesAsync();
            return paymentMethod;
        }

        public async Task<bool> UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            var existingPaymentMethod = await dbContext.PaymentMethods.FindAsync(paymentMethod.Id);
            if (existingPaymentMethod == null)
                return false;

            existingPaymentMethod.Title = paymentMethod.Title;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePaymentMethod(int id)
        {
            var existingPaymentMethod = await dbContext.PaymentMethods.FindAsync(id);
            if (existingPaymentMethod == null)
                return false;

            dbContext.PaymentMethods.Remove(existingPaymentMethod);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
