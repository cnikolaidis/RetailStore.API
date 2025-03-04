using RetailStore.ApplicationLayer.Models;

namespace RetailStore.ApplicationLayer.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomers();
        Task<CustomerDto?> GetCustomerById(int id);
        Task<CustomerDto> CreateCustomer(CustomerDto dto);
        Task<bool> UpdateCustomer(CustomerDto dto);
        Task<bool> DeleteCustomer(int id);
    }
}
