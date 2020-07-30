using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;

namespace RestorauntManagement.Services.Intefaces
{
    public interface IProductService
    {
        ActionMessage Add(ProductViewModel model);
    }
}
