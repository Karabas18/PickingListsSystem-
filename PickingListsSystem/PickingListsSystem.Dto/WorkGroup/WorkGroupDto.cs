using PickingListsSystem.Dto.User;

namespace PickingListsSystem.Dto.WorkGroup
{
    public class WorkGroupDto : CreateWorkGroupDto
    {
        public int Id { get; set; }

        public UserDto? WorkGroupDirector { get; set; }
    }
}
