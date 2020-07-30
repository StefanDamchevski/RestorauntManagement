using RestorauntManagement.Models;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.User;
using System.Threading.Tasks;

namespace RestorauntManagement.Services.Intefaces
{
    public interface IUserService
    {
        Task<ActionMessage> CreateAsync(InputResgisterViewModel model);
        Task<ApplicationUser> GetById(string userId);
        ManageUsersViewModel GetAll();
    }
}
