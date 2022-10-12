using ItemTransactionsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemTransactionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAllCategories()
        {
            if (ModelState.IsValid)
            {
                List<Category> categories = _context.Category.Include(x=>x.Item).ToList();

                return Ok(categories);
            }
            else
            {
                return BadRequest("No Categories Found");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult deleteCategory(int id)
        {
            if (ModelState.IsValid) { 
                Category category = _context.Category.Find(id);
                if (category != null) { 
                _context.Remove(category);
                _context.SaveChanges();
                    
                }
                else
                {
                    return BadRequest("there is no category matches this");
                }
                
            }
            return Ok("Category Deleted");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            Category category = _context.Category.Include(x=>x.Item).ThenInclude(x=>x.Unit).Where(x=>x.Id == id).FirstOrDefault();
            
            return Ok(category);
            
        }



        [HttpPut("{id}")]

        public IActionResult Update(int id, Category newCategory)
        {
            if (id != newCategory.Id) 
            {
            return BadRequest("Invalid Id");
            };
            Category category = _context.Category.Find(id);

            category.CategoryName = newCategory.CategoryName;
            _context.SaveChanges();

            return Ok(newCategory);

        }

    }
}
