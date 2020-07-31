using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.Models
{
    public class ProductRecepit
    {
        public int Id { get; set; }
        [Required]
        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
