using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using RestorauntManagement.Models;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntManagement.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<ActionMessage> CreateRoleAsync(string roleName)
        {
            ActionMessage response = new ActionMessage();

            bool exists = roleManager.Roles.Where(x => x.Name.Equals(roleName)).Any();

            if (!exists)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleName;

                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    response.Message = "Create Successful";
                }
            }
            else
            {
                response.Error = $"Role {roleName} already exists";
            }

            return response;
        }

        public List<IdentityRole> GetAll()
        {
            return roleManager.Roles.ToList();
        }

        public async Task GiveUserRoleAsync(string roleName, string userId)
        {
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task RemoveUserRoleAsync(string roleName, string userId)
        {
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            await userManager.RemoveFromRoleAsync(user, roleName);
        }
    }
}
