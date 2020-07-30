using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}