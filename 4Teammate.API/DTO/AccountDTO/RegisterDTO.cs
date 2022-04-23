using System.ComponentModel.DataAnnotations;

namespace _4Teammate.API.DTO.AccountDTO
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must Be complex")]
        public string Password { get; set; }
    }
}
