using Microsoft.AspNetCore.Identity;
using RestorauntManagement.ViewModels.ActionMessage;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestorauntManagement.Services.Intefaces
{
    public interface IRoleService
    {
        Task<ActionMessage> CreateRoleAsync(string roleName);
        List<IdentityRole> GetAll();
        Task GiveUserRoleAsync(string roleName, string userId);
        Task RemoveUserRoleAsync(string roleName, string userId);
    }
}
