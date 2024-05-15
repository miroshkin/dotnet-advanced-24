using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Service.Clean.Architecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CatalogServiceDbContext _context;

        public CategoriesController(CatalogServiceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}", Name = nameof(GetCategory))] // Define a route for getting a category by ID
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet(Name = "GetAllCategories")]
        public ActionResult<IEnumerable<Category>> GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories); // Return 200 with the categories list
        }

        [HttpPost(Name = "AddCategory")]
        public ActionResult<Category> AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return CreatedAtRoute("GetCategoryById", new { categoryId = category.CategoryId }, category);
        }

        [HttpDelete("{categoryId}", Name = "DeleteCategory")]
        public IActionResult RemoveCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
            {
                return NotFound(); // Return 404 if category is not found
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent(); // Return 204 for successful deletion
        }

        [HttpPut("{categoryId}", Name = "UpdateCategory")]
        public IActionResult UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId)
            {
                return BadRequest(); // Return 400 for invalid request
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            return NoContent(); // Return 204 for successful update
        }
    }
}
