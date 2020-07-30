using Microsoft.AspNetCore.Identity;
using RestorauntManagement.Models;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Auth;
using System.Linq;
using System.Threading.Tasks;

namespace RestorauntManagement.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AuthService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<ActionMessage> AdminSignInAsync(InputLoginModel model)
        {
            ActionMessage response = new ActionMessage();

            ApplicationUser user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    response.Message = "Login Successful!!";
                }
                else
                {
                    response.Error = "Password and Email did not match";
                }
            }
            else
            {
                response.Error = "Login Failed!! Account doesn`t Exist";
            }
            return response;
        }

        public async Task<ActionMessage> SignInAsync(PinLoginModel model)
        {
            ActionMessage response = new ActionMessage();

            ApplicationUser user = userManager.Users.FirstOrDefault(x => x.UserPin.Equals(model.UserPin));

            if(user != null)
            {
                await signInManager.SignInAsync(user, false);
                response.Message = "Login Successful";
            }
            else
            {
                response.Error = "Login Failed";
            }
            return response;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}