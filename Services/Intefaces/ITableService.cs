using RestorauntManagement.Models;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;
using RestorauntManagement.ViewModels.Table;
using System.Collections.Generic;

namespace RestorauntManagement.Services.Intefaces
{
    public interface ITableService
    {
        ActionMessage Add(string tableName);
        List<TableOverviewModel> GetAll();
        void Reserve(int tableId, string name);
        Table GetById(int tableId);
        void Close(int tableId);
        void AddProductsToTable(int tableId, List<AddToTableProductModel> products);
    }
}
