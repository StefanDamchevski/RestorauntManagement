using RestorauntManagement.Models;
using RestorauntManagement.ViewModels.Product;
using RestorauntManagement.ViewModels.ProductReceipts;
using RestorauntManagement.ViewModels.Table;
using RestorauntManagement.ViewModels.User;
using System.Linq;

namespace RestorauntManagement.Helper
{
    public static class ModelConverter
    {
        public static AccountDetailsModel ToAccountDetailsModel(this ApplicationUser user)
        {
            return new AccountDetailsModel
            {
                UserId = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                UserPin = user.UserPin,
            };
        }

        public static TableOverviewModel ToTableOverviewModel(this Table table)
        {
            return new TableOverviewModel
            {
                Id = table.Id,
                TableName = table.TableName,
                IsAvailable = table.IsAvailable,
                ServedBy = table.ServedBy,
            };
        }

        public static TableDetailsModel ToTableDetailsModel(this Table table)
        {
            return new TableDetailsModel
            {
                Id = table.Id,
                TableName = table.TableName,
                Products = table.Receipts
                        .FirstOrDefault(x => !x.DateClosed.HasValue)
                        .ProductRecepits.Select(x => x.ToProductReceiptViewModel())
                        .ToList(),
            };
        }

        public static ProductReceiptModel ToProductReceiptViewModel(this ProductRecepit recepit)
        {
            return new ProductReceiptModel
            {
                Id = recepit.Id,
                Name = recepit.Product.Name,
                Price = recepit.Price,
                Quantity = recepit.Quantity,
            };
        }

        public static ProductViewModel ToProductViewModel(this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }
    }
}