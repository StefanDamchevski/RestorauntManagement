using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.Helper;
using RestorauntManagement.Models;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.User;
using System.Threading.Tasks;

namespace RestorauntManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ManageUsers()
        {
            ManageUsersViewModel model = userService.GetAll();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            InputResgisterViewModel model = new InputResgisterViewModel();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(InputResgisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = await userService.CreateAsync(model);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Details(string userId)
        {
            ApplicationUser user = await userService.GetById(userId);
            AccountDetailsModel model = user.ToAccountDetailsModel();
            return View(model);
        }
    }
}
