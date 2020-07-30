using RestorauntManagement.Models;
using RestorauntManagement.Repositories.Interfaces;
using RestorauntManagement.Services.Intefaces;
using RestorauntManagement.ViewModels.ActionMessage;
using RestorauntManagement.ViewModels.Product;

namespace RestorauntManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionMessage Add(ProductViewModel model)
        {
            ActionMessage response = new ActionMessage();
            Product product = productRepository.GetByName(model.Name);

            if(product == null)
            {
                Product newProduct = new Product();
                newProduct.Name = model.Name;
                newProduct.Price = model.Price;
                newProduct.Quantity = model.Quantity;

                productRepository.Add(newProduct);
                response.Message = "Product successfuly created";
            }
            else
            {
                response.Error = $"Create Failed. Product with name {model.Name} already exists";
            }
            return response;
        }
    }
}
