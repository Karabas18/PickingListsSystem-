// методы для работы с баззой данных 
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(PlsDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<List<Customer>> GetCustomer()
        {
            var result = await _dbContext.Customer.ToListAsync();
            return result;
        }

        public async Task<Customer> GetCustomerID(int id)
        {
            var result = await _dbContext.Customer.FirstOrDefaultAsync(customer => customer.Id == id);
            return result;
        }

        public async Task DeleteCustomer(int id)
        {
            var result = await _dbContext.Customer.FindAsync(id);

            if (result != null)
            {
                _dbContext.Customer.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _dbContext.Customer.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _dbContext.Customer.Update(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
