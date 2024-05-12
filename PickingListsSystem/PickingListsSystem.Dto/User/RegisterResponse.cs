using System.ComponentModel.DataAnnotations;

namespace PickingListsSystem.Dto.User
{
    public class RegisterResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }
    }
}

