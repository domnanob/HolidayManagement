using System.ComponentModel.DataAnnotations;

namespace HolidayManagement.Models.Login
{
    public class LoginUser
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        public string? Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Institution is required")]
        public string? InstitutionId { get; set; }
    }
}
