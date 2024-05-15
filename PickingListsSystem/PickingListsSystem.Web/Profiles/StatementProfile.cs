using AutoMapper;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class StatementProfile : Profile
    {
        public StatementProfile()
        {
            //First try
            //CreateMap<Statement, StatementDto>().ReverseMap();
            //CreateMap<CreateStatementDto, Statement>().ReverseMap();
            //Second try
            //CreateMap<Statement, StatementDto>()
            //    .IncludeMembers(src => src.Materials);
            //CreateMap<CreateStatementDto, Statement>().ReverseMap();
            //
            CreateMap<Statement, StatementDto>()
            .ForMember(dest => dest.Materials, opt => opt.MapFrom(src => src.Materials));

            CreateMap<CreateStatementDto, Statement>().ReverseMap();
        }
    }
}
