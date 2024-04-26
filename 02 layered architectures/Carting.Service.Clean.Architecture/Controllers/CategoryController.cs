using Carting.Service.BLL;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Service.Clean.Architecture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICartBll _cartBll;
        private readonly CatalogServiceDbContext _context; 

        public CategoryController(ILogger<CategoryController> logger, CatalogServiceDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetCategory")]
        public Category GetCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException();
            }
            return category;
        }

        [HttpGet(Name = "GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        [HttpPost(Name = "AddCategory")]
        public void AddCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }

        [HttpDelete(Name = "DeleteCategory")]
        public void RemoveCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        [HttpPut(Name = "UpdateCategory")]
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}