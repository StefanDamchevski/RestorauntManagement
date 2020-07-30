using RestorauntManagement.ViewModels.Product;
using System.Collections.Generic;

namespace RestorauntManagement.ViewModels.Table
{
    public class TableDetailsModel
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
