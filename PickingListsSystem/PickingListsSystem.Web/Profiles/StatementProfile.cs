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
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

            CreateMap<CreateStatementDto, Statement>().ReverseMap();
        }
    }
}
