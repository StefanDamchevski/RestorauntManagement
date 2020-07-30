using RestorauntManagement.Models;
using RestorauntManagement.Repositories.Interfaces;
using System.Linq;

namespace RestorauntManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly RestorauntManagementDbContext context;

        public ProductRepository(RestorauntManagementDbContext context)
        {
            this.context = context;
        }

        public void Add(Product model)
        {
            context.Products.Add(model);
            context.SaveChanges();
        }

        public Product GetByName(string name)
        {
            return context.Products.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
