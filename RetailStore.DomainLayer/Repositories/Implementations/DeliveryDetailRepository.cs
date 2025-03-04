using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class DeliveryDetailRepository(RetailStoreDbContext dbContext) : IDeliveryDetailRepository
    {
        public async Task<IEnumerable<DeliveryDetail>> GetDeliveryDetails()
        {
            return await dbContext.DeliveryDetails.ToListAsync();
        }

        public async Task<DeliveryDetail?> GetDeliveryDetailById(int id)
        {
            return await dbContext.DeliveryDetails.FindAsync(id);
        }

        public async Task<DeliveryDetail> CreateDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            deliveryDetail.DateCreated = DateTime.Now;
            await dbContext.DeliveryDetails.AddAsync(deliveryDetail);
            await dbContext.SaveChangesAsync();
            return deliveryDetail;
        }

        public async Task<bool> UpdateDeliveryDetail(DeliveryDetail deliveryDetail)
        {
            var existingDeliveryDetail = await dbContext.DeliveryDetails.FindAsync(deliveryDetail.Id);
            if (existingDeliveryDetail == null)
                return false;

            existingDeliveryDetail.DeliveryId = deliveryDetail.DeliveryId;
            existingDeliveryDetail.DeliveryStatusId = deliveryDetail.DeliveryStatusId;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDeliveryDetail(int id)
        {
            var existingDeliveryDetail = await dbContext.DeliveryDetails.FindAsync(id);
            if (existingDeliveryDetail == null)
                return false;

            dbContext.DeliveryDetails.Remove(existingDeliveryDetail);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
