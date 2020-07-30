using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestorauntManagement.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        [Required]
        public int TableId { get; set; }
        public Table Table { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
        public List<ProductRecepit> ProductRecepits { get; set; }
    }
}
