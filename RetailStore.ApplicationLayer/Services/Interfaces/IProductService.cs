using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto?> GetProductById(int id);
        Task<ProductDto> CreateProduct(ProductDto dto);
        Task<bool> UpdateProduct(ProductDto dto);
        Task<bool> DeleteProduct(int id);
    }
}
