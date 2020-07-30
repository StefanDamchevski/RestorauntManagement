using Microsoft.AspNetCore.Identity;
using RestorauntManagement.Models;
using System.Collections.Generic;

namespace RestorauntManagement.ViewModels.User
{
    public class ManageUsersViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}