using AutoMapper;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class StatementProfile : Profile
    {
        public StatementProfile()
        {
            
            CreateMap<Statement, StatementDto>()
            .ForMember(dest => dest.Materials, opt => opt.MapFrom(src => src.Materials));

            CreateMap<CreateStatementDto, Statement>().ReverseMap();
        }
    }
}
