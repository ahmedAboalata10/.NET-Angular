using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace MLG_Interview.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
