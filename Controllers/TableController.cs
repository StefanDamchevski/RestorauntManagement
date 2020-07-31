using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestorauntManagement.Helper;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Table;
using System.Collections.Generic;

namespace RestorauntManagement.Controllers
{
    [Authorize]
    public class TableController : Controller
    {
        private readonly ITableService tableService;

        public TableController(ITableService tableService)
        {
            this.tableService = tableService;
        }

        public IActionResult Overview()
        {
            List<TableOverviewModel> models = tableService.GetAll();
            return View(models);
        }

        public IActionResult ReserveTable(int tableId)
        {
            tableService.Reserve(tableId, User.Identity.Name);
            return RedirectToAction(nameof(Overview));
        }

        public IActionResult CloseTable(int tableId)
        {
            tableService.Close(tableId);
            return RedirectToAction(nameof(Overview));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IActionResult Create(string tableName)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                ActionMessage response = tableService.Add(tableName);
                return RedirectToAction("ActionMessage", "Message", response);
            }
            return View();
        }

        public IActionResult Details(int tableId)
        {
            TableDetailsModel model = tableService.GetById(tableId).ToTableDetailsModel(); 
            return View(model);
        }

        [HttpPost]
        public IActionResult AddToTable([FromBody]AddToTableViewModel model)
        {
            tableService.AddProductsToTable(model.TableId, model.Products);
            return Ok();
        }
    }
}