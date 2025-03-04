using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class DeliveryStatusRepository(RetailStoreDbContext dbContext) : IDeliveryStatusRepository
    {
        public async Task<IEnumerable<DeliveryStatus>> GetDeliveryStatuses()
        {
            return await dbContext.DeliveryStatuses.ToListAsync();
        }

        public async Task<DeliveryStatus?> GetDeliveryStatusById(int id)
        {
            return await dbContext.DeliveryStatuses.FindAsync(id);
        }

        public async Task<DeliveryStatus> CreateDeliveryStatus(DeliveryStatus deliveryStatus)
        {
            await dbContext.DeliveryStatuses.AddAsync(deliveryStatus);
            await dbContext.SaveChangesAsync();
            return deliveryStatus;
        }

        public async Task<bool> UpdateDeliveryStatus(DeliveryStatus deliveryStatus)
        {
            var existingDeliveryStatus = await dbContext.DeliveryStatuses.FindAsync(deliveryStatus.Id);
            if (existingDeliveryStatus == null)
                return false;

            existingDeliveryStatus.Title = deliveryStatus.Title;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDeliveryStatus(int id)
        {
            var existingDeliveryStatus = await dbContext.DeliveryStatuses.FindAsync(id);
            if (existingDeliveryStatus == null)
                return false;

            dbContext.DeliveryStatuses.Remove(existingDeliveryStatus);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
