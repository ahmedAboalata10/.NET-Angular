using System.ComponentModel.DataAnnotations;

namespace Models.Auth
{
    public class RegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "PASSWORDS_DO_NOT_MATCH")]
        public string ConfirmPassword { get; set; }
    }
}
