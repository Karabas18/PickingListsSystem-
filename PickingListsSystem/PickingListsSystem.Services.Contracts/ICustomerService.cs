using PickingListsSystem.Dto.Customer;

namespace PickingListsSystem.Services.Contracts
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> GetCustomer();
        Task<CustomerDto> GetCustomerID(int id);
        Task DeleteCustomer(int id);
        Task<int> AddCustomer(CreateCustomerDto customer);
        Task<int> UpdateCustomer(CustomerDto customer);
    }
}