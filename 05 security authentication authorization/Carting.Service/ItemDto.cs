using System.ComponentModel.DataAnnotations;

namespace Carting.Service
    {
    public class ItemDto
        {
        public int? Id { get; set; }

        public string Name { get; set; }

        public Image Image { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }
        }
    }