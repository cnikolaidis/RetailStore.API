using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class OrderItemRepository(RetailStoreDbContext dbContext) : IOrderItemRepository
    {
        public async Task<IEnumerable<OrderItem>> GetOrderItems()
        {
            return await dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetOrderItemById(int id)
        {
            return await dbContext.OrderItems.FindAsync(id);
        }

        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            orderItem.DateCreated = DateTime.Now;
            await dbContext.OrderItems.AddAsync(orderItem);
            await dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task<bool> UpdateOrderItem(OrderItem orderItem)
        {
            var existingOrderItem = await dbContext.OrderItems.FindAsync(orderItem.Id);
            if (existingOrderItem == null)
                return false;

            existingOrderItem.OrderId = orderItem.OrderId;
            existingOrderItem.ProductId= orderItem.ProductId;
            existingOrderItem.SubTotal = orderItem.SubTotal;
            existingOrderItem.Quantity = orderItem.Quantity;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOrderItem(int id)
        {
            var existingOrderItem = await dbContext.OrderItems.FindAsync(id);
            if (existingOrderItem == null)
                return false;

            dbContext.OrderItems.Remove(existingOrderItem);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
