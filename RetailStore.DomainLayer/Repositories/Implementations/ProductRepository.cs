using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class ProductRepository(RetailStoreDbContext dbContext) : IProductRepository
    {
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(Product product)
        {
            product.DateCreated = DateTime.Now;
            product.DateUpdated = DateTime.Now;
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var existingProduct = await dbContext.Products.FindAsync(product.Id);
            if (existingProduct == null)
                return false;

            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.DateUpdated = DateTime.Now;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var existingProduct = await dbContext.Products.FindAsync(id);
            if (existingProduct == null)
                return false;

            dbContext.Products.Remove(existingProduct);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
