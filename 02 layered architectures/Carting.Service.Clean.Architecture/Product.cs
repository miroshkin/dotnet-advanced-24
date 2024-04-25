using System.ComponentModel.DataAnnotations;

namespace Carting.Service
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public uint Amount { get; set; } 
    }
}