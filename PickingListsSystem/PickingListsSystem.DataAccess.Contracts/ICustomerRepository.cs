using PickingListsSystem.Entities;

namespace PickingListsSystem.DataAccess.Contracts
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomer();
        Task<Customer> GetCustomerID(int id);
        Task DeleteCustomer(int id);
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
    }
}