using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Customer;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<CustomerDto>> GetAll()
        {
            return await _customerService.GetCustomer();
        }

        [HttpGet("getbyid")]
        public async Task<CustomerDto> GetID(int id)
        {
            return await _customerService.GetCustomerID(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CreateCustomerDto customer)
        {
            return await _customerService.AddCustomer(customer);
        }

        [HttpPut]
        public async Task<int> Update([FromBody] CustomerDto customer)
        {
            return await _customerService.UpdateCustomer(customer);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _customerService.DeleteCustomer(id);
        }

    }
}