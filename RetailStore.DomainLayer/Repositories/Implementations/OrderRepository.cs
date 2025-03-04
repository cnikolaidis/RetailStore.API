using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class OrderRepository(RetailStoreDbContext dbContext) : IOrderRepository
    {
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await dbContext.Orders
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.Payment).ThenInclude(p => p.PaymentMethod)
                .Include(o => o.Delivery).ThenInclude(d => d.DeliveryDetails).ThenInclude(dd => dd.DeliveryStatus)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await dbContext.Orders.FindAsync(id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            order.DateCreated = DateTime.Now;
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            var existingOrder = await dbContext.Orders.FindAsync(order.Id);
            if (existingOrder == null)
                return false;

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.TotalAmount = order.TotalAmount;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var existingOrder = await dbContext.Orders.FindAsync(id);
            if (existingOrder == null)
                return false;

            dbContext.Orders.Remove(existingOrder);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
