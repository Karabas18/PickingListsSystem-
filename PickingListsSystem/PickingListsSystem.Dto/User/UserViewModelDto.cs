using System.ComponentModel.DataAnnotations;

namespace PickingListsSystem.Dto.User
{
    public class UserViewModelDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(250, ErrorMessage = "Name can't be more than 250 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(250, ErrorMessage = "Name can't be more than 250 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "E-mail is required.")]
        [EmailAddress]
        [StringLength(250, ErrorMessage = "E-mail can't be more than 250 characters.")]
        public string? Email { get; set; }
    }
}
