using AutoMapper;
using PickingListsSystem.Dto.Customer;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();
        }
    }
}
