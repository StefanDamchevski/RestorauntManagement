using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.Helper;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;
using System.Linq;

namespace RestorauntManagement.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = productService.Add(model);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View(model);
        }

        public IActionResult ShowMenu(int tableId)
        {
            MenuViewModel model = new MenuViewModel();
            model.Products = productService.GetAll().Select(x => x.ToProductViewModel()).ToList();
            model.TableId = tableId;
            return View(model);
        }
    }
}