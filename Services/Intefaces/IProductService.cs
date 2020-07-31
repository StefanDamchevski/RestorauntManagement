using RestorauntManagement.Models;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;
using System.Collections.Generic;

namespace RestorauntManagement.Services.Intefaces
{
    public interface IProductService
    {
        ActionMessage Add(ProductViewModel model);
        List<Product> GetAll();
        List<Product> GetAllIds(List<int> lists);
        void UpdateRange(List<Product> updatedProducts);
    }
}
