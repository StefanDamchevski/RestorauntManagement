using RestorauntManagement.ViewModels.Product;
using System.Collections.Generic;

namespace RestorauntManagement.ViewModels.Table
{
    public class AddToTableViewModel
    {
        public List<AddToTableProductModel> Products { get; set; }
        public int TableId { get; set; }
    }
}
