using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Auth;
using System.Threading.Tasks;

namespace RestorauntManagement.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Overview", "Table");
            }
            PinLoginModel model = new PinLoginModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(PinLoginModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = await authService.SignInAsync(model);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View(model);
        }

        [Route("admin/login")]
        public IActionResult AdminLogin()
        {
            InputLoginModel model = new InputLoginModel();
            return View(model);
        }

        public async Task<IActionResult> AdminLogin(InputLoginModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = await authService.AdminSignInAsync(model);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await authService.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}