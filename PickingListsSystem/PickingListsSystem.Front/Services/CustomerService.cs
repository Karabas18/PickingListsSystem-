using PickingListsSystem.Dto.Customer;
using PickingListsSystem.Services.Contracts;
using System.Net.Http.Json;

namespace PickingListsSystem.Front.Services
{
    public class CustomerService : ICustomerService
    {

        protected readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> AddCustomer(CreateCustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerDto>> GetCustomer()
        {
            var response = await _httpClient.GetFromJsonAsync<List<CustomerDto>>("Customer");
            return response ?? throw new HttpRequestException("Couldn't get work types");
        }

        public Task<CustomerDto> GetCustomerID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }

}