using RestorauntManagement.Models;
using RestorauntManagement.Repositories.Interfaces;
using System.Collections.Generic;
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

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public List<Product> GetByIds(List<int> ids)
        {
            return context.Products.Where(x => ids.Contains(x.Id)).ToList();
        }

        public Product GetByName(string name)
        {
            return context.Products.FirstOrDefault(x => x.Name.Equals(name));
        }

        public void UpdateRange(List<Product> updatedProducts)
        {
            context.Products.UpdateRange(updatedProducts);
            context.SaveChanges();
        }
    }
}
