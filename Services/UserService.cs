using Microsoft.AspNetCore.Identity;
using RestorauntManagement.Models;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.User;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRoleService roleService;

        public UserService(UserManager<ApplicationUser> userManager, IRoleService roleService)
        {
            this.userManager = userManager;
            this.roleService = roleService;
        }

        public async Task<ActionMessage> CreateAsync(InputResgisterViewModel model)
        {
            ActionMessage response = new ActionMessage();

            bool exists = userManager.Users.Where(x => x.UserName.Equals(model.UserName) || x.UserPin.Equals(model.UserPin)).Any();

            if (!exists)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.UserPin = model.UserPin;

                IdentityResult result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    response.Message = "Create successfull.";
                }
                else
                {
                    response.Error = "Create Failed!!";
                }
            }
            else
            {
                response.Error = $"Create failed. User with {model.UserName} or {model.UserPin} already exists";
            }
            return response;
        }

        public ManageUsersViewModel GetAll()
        {
            ManageUsersViewModel model = new ManageUsersViewModel();
            model.Users = userManager.Users.ToList();
            model.Roles = roleService.GetAll();
            return model;
        }

        public async Task<ApplicationUser> GetById(string userId)
        {
            ApplicationUser user = await userManager.FindByIdAsync(userId);
            return user;
        }
    }
}