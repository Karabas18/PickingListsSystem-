using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.Role;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<int> AddRole(CreateRoleDto role)
        {
            var entitytoAdd = _mapper.Map<CreateRoleDto, Role>(role);
            await _roleRepository.AddRole(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteRole(int id)
        {
            await _roleRepository.DeleteRole(id);
        }

        public async Task<RoleDto> GetRoleID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var role = await _roleRepository.GetRoleID(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<List<RoleDto>> GetRole()
        {
            var role = await _roleRepository.GetRole();
            return _mapper.Map<List<RoleDto>>(role);
        }

        public async Task<int> UpdateRole(RoleDto role)
        {
            var entitytoUpdate = _mapper.Map<CreateRoleDto, Role>(role);
            await _roleRepository.UpdateRole(entitytoUpdate);
            return entitytoUpdate.Id;
        }
    }
}