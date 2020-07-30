using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;

namespace RestorauntManagement.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                ActionMessage response = productService.Add(model);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View(model);
        }
    }
}