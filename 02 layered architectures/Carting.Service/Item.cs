using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carting.Service
{
    public class Item
    {
        public int CartId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Image Image { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; } 
    }
}