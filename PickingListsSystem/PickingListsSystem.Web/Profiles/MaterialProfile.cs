using AutoMapper;
using PickingListsSystem.Dto.Materials;
using PickingListsSystem.Entities;

namespace PickingListsSystem.API.Profiles
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDto>().ReverseMap();
        }
    }
}
