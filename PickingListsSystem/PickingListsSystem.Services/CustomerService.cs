using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Customer;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<int> AddCustomer(CreateCustomerDto customer)
        {
            var entitytoAdd = _mapper.Map<CreateCustomerDto, Customer>(customer);
            await _customerRepository.AddCustomer(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteCustomer(int id)
        {
            await _customerRepository.DeleteCustomer(id);
        }

        public async Task<CustomerDto> GetCustomerID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var customer = await _customerRepository.GetCustomerID(id);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetCustomer()
        {
            var customer = await _customerRepository.GetCustomer();
            return _mapper.Map<List<CustomerDto>>(customer);
        }

        public async Task<int> UpdateCustomer(CustomerDto customer)
        {
            var entitytoUpdate = _mapper.Map<CreateCustomerDto, Customer>(customer);
            await _customerRepository.UpdateCustomer(entitytoUpdate);
            return entitytoUpdate.Id;
        }
    }
}