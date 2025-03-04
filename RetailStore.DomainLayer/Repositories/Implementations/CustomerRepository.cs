using RetailStore.DomainLayer.Repositories.Interfaces;
using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RetailStore.DomainLayer.Core;

namespace RetailStore.DomainLayer.Repositories.Implementations
{
    public class CustomerRepository(RetailStoreDbContext dbContext) : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await dbContext.Customers.FindAsync(id);
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            customer.DateCreated = DateTime.Now;
            customer.DateUpdated = DateTime.Now;
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await dbContext.Customers.FindAsync(customer.Id);
            if (existingCustomer == null)
                return false;

            existingCustomer.FullName = customer.FullName;
            existingCustomer.MailAddress = customer.MailAddress;
            existingCustomer.PhoneNo = customer.PhoneNo;
            existingCustomer.BirthDate = customer.BirthDate;
            existingCustomer.DateUpdated = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var existingCustomer = await dbContext.Customers.FindAsync(id);
            if (existingCustomer == null)
                return false;

            dbContext.Customers.Remove(existingCustomer);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}
