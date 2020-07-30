using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.ViewModels.ActionMessage;

namespace RestorauntManagement.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult ActionMessage(ActionMessage model) => View(model);
    }
}