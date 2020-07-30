using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Auth;
using System.Threading.Tasks;

namespace RestorauntManagement.Services.Intefaces
{
    public interface IAuthService
    {
        Task<ActionMessage> SignInAsync(PinLoginModel model);
        Task SignOutAsync();
        Task<ActionMessage> AdminSignInAsync(InputLoginModel model);
    }
}
