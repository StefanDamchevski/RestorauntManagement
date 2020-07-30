using Microsoft.AspNetCore.Identity;

namespace RestorauntManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserPin { get; set; }
    }
}
