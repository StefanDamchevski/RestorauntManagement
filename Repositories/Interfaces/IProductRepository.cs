using RestorauntManagement.Models;
using System.Collections.Generic;

namespace RestorauntManagement.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product model);
        Product GetByName(string name);
        List<Product> GetAll();
        List<Product> GetByIds(List<int> ids);
        void UpdateRange(List<Product> updatedProducts);
    }
}
