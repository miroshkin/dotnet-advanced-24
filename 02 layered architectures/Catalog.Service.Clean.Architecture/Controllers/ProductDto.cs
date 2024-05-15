using static Catalog.Service.Clean.Architecture.Controllers.ProductsController;

namespace Catalog.Service.Clean.Architecture.Controllers
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // Add other properties as needed
        public LinkDto Category { get; set; } // Link to the category
    }
}
