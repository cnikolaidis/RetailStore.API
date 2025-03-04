using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class DeliveryRepository(RetailStoreDbContext dbContext) : IDeliveryRepository
    {
        public async Task<IEnumerable<Delivery>> GetDeliveries()
        {
            return await dbContext.Deliveries.ToListAsync();
        }

        public async Task<Delivery?> GetDeliveryById(int id)
        {
            return await dbContext.Deliveries.FindAsync(id);
        }

        public async Task<Delivery> CreateDelivery(Delivery delivery)
        {
            delivery.DateCreated = DateTime.Now;
            await dbContext.Deliveries.AddAsync(delivery);
            await dbContext.SaveChangesAsync();
            return delivery;
        }

        public async Task<bool> UpdateDelivery(Delivery delivery)
        {
            var existingDelivery = await dbContext.Deliveries.FindAsync(delivery.OrderId);
            if (existingDelivery == null)
                return false;

            existingDelivery.TrackingNumber = delivery.TrackingNumber;
            existingDelivery.OrderId = delivery.OrderId;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDelivery(int id)
        {
            var existingDelivery = await dbContext.Deliveries.FindAsync(id);
            if (existingDelivery == null)
                return false;

            dbContext.Deliveries.Remove(existingDelivery);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
