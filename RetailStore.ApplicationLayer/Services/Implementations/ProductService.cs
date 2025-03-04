using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class ProductService(IProductRepository repo, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await repo.GetProducts();
            return products.Select(x => mapper.Map<ProductDto>(x));
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            var product = await repo.GetProductById(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateProduct(ProductDto dto)
        {
            var product = mapper.Map<ProductDto, Product>(dto);
            var productEntity = await repo.CreateProduct(product);
            return mapper.Map<Product, ProductDto>(productEntity);
        }

        public async Task<bool> UpdateProduct(ProductDto dto)
        {
            var p = mapper.Map<Product>(dto);
            return await repo.UpdateProduct(p);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await repo.DeleteProduct(id);
        }
    }
}
