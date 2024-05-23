using AutoMapper;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class StatementProfile : Profile
    {
        public StatementProfile()
        {

            //CreateMap<Statement, StatementDto>()
            //.ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project));

            CreateMap<Statement, StatementDto>()
            .ForMember(dest => dest.Project, opt => opt.MapFrom(src => src.Project)).ReverseMap();
            //Проверка
            CreateMap<CreateStatementDto, Statement>().ReverseMap();
        }
    }
}
