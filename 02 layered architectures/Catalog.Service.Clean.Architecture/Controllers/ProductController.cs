using Carting.Service.Clean.Architecture.Controllers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Service.Clean.Architecture.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly CatalogServiceDbContext _context;

    public ProductsController(CatalogServiceDbContext context)
    {
        _context = context;
    }

    // GET: api/Products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }
    [HttpGet]
    [Route("FilteringAndPagination")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsWithFilteringAndPagination(int? categoryId, int page, int pageSize)
    {
        IQueryable<Product> query = _context.Products.Include(p => p.Category); // Include Category in the query

        // Apply filtering by category ID if provided
        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId);
        }

        // Apply pagination
        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        var products = await query.Skip((page - 1) * pageSize)
                                  .Take(pageSize)
                                  .ToListAsync();

        // Generate HATEOAS links for each product
        var productDtos = new List<ProductDto>();
        foreach (var product in products)
        {
            var productDto = new ProductDto
            {
                Id = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                // Add other properties as needed
                Category = new LinkDto(Url.Link(nameof(CategoriesController.GetCategory), new { id = product.CategoryId }), "category", "GET") // Link to the category
            };
            productDtos.Add(productDto);
        }

        // Create the response object
        var result = new
        {
            TotalCount = totalCount,
            TotalPages = totalPages,
            Page = page,
            PageSize = pageSize,
            Products = productDtos
        };

        return Ok(result);
    }

    // GET: api/Products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    // POST: api/Products
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
    }

    // PUT: api/Products/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.ProductId == id);
    }
}