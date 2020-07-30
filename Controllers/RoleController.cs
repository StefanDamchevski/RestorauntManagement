using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.Models;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using System.Threading.Tasks;

namespace RestorauntManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        private readonly UserManager<ApplicationUser> userManager;

        public RoleController(IRoleService roleService, UserManager<ApplicationUser> userManager)
        {
            this.roleService = roleService;
            this.userManager = userManager;
        }
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                ActionMessage response = await roleService.CreateRoleAsync(roleName);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View();
        }

        public async Task<IActionResult> AddRole(string roleName, string userId)
        {
            await roleService.GiveUserRoleAsync(roleName, userId);
            return RedirectToAction("ManageUsers", "User");
        }
        public async Task<IActionResult> RemoveRole(string roleName, string userId)
        {
            await roleService.RemoveUserRoleAsync(roleName, userId);
            ApplicationUser currentUser = await userManager.GetUserAsync(User);

            if (currentUser.Id == userId && roleName == "Admin")
            {
                return RedirectToAction("Logout", "Auth");
            }

            return RedirectToAction("ManageUsers", "User");
        }
    }
}