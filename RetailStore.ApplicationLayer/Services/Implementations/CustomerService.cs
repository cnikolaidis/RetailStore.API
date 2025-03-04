using RetailStore.ApplicationLayer.Services.Interfaces;
using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.ApplicationLayer.Models;
using RetailStore.DomainLayer.Entities;
using AutoMapper;

namespace RetailStore.ApplicationLayer.Services.Implementations
{
    public class CustomerService(ICustomerRepository repo, IMapper mapper) : ICustomerService
    {
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var Customers = await repo.GetCustomers();
            return Customers.Select(x => mapper.Map<CustomerDto>(x));
        }

        public async Task<CustomerDto?> GetCustomerById(int id)
        {
            var Customer = await repo.GetCustomerById(id);
            return mapper.Map<CustomerDto>(Customer);
        }

        public async Task<CustomerDto> CreateCustomer(CustomerDto dto)
        {
            var Customer = mapper.Map<CustomerDto, Customer>(dto);
            var CustomerEntity = await repo.CreateCustomer(Customer);
            return mapper.Map<Customer, CustomerDto>(CustomerEntity);
        }

        public async Task<bool> UpdateCustomer(CustomerDto dto)
        {
            var p = mapper.Map<Customer>(dto);
            return await repo.UpdateCustomer(p);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await repo.DeleteCustomer(id);
        }
    }
}
