using AutoMapper;
using PickingListsSystem.DataAccess.Contracts;
using PickingListsSystem.Dto.User;
using PickingListsSystem.Entities;
using PickingListsSystem.Services.Contracts;

namespace PickingListsSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<int> AddUser(CreateUserDto user)
        {
            var entitytoAdd = _mapper.Map<CreateUserDto, User>(user);
            await _userRepository.AddUser(entitytoAdd);
            return entitytoAdd.Id;
        }

        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        public async Task<UserDto> GetUserID(int id)
        {
            //return _mapper.Map<MaterialDto>(await _materialRepository.GetMaterialID(id));
            var user = await _userRepository.GetUserID(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDto>> GetUser()
        {
            var user = await _userRepository.GetUser();
            return _mapper.Map<List<UserDto>>(user);
        }

        public async Task<int> UpdateUser(UserDto user)
        {
            var entitytoUpdate = _mapper.Map<CreateUserDto, User>(user);
            await _userRepository.UpdateUser(entitytoUpdate);
            return entitytoUpdate.Id;
        }
    }
}