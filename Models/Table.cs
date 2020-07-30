using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.Models
{
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public string TableName { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
