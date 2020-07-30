using RestorauntManagement.Models;

namespace RestorauntManagement.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product model);
        Product GetByName(string name);
    }
}
