using RestorauntManagement.ViewModels.ProductReceipts;
using System.Collections.Generic;

namespace RestorauntManagement.ViewModels.Table
{
    public class TableDetailsModel
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public List<ProductReceiptModel> Products { get; set; }
    }
}
