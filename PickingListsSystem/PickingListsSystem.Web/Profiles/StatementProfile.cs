using AutoMapper;
using PickingListsSystem.Dto.Statement;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class StatementProfile : Profile
    {
        public StatementProfile()
        {
            CreateMap<Statement, StatementDto>().ReverseMap();
            CreateMap<CreateStatementDto, Statement>().ReverseMap();
        }
    }
}
