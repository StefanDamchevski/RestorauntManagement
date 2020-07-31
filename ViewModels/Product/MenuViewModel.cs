using System.Collections.Generic;

namespace RestorauntManagement.ViewModels.Product
{
    public class MenuViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public int TableId { get; set; }
    }
}
