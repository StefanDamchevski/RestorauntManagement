using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public List<ProductRecepit> ProductRecepits { get; set; }
    }
}
