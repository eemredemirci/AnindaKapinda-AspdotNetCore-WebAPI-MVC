using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        public CategoryController(AnindaKapindaDbContext context) : base(context)
        {

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            List<Category> categories = context.Categories.Where(c => c.ID == id).ToList();
            if (categories.Count != 0)
            {
                return Ok(categories);
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {

            if (account == null)
            {
                return NotFound("Admin bulunamadı");
            }
            else
            {
                context.Categories.Add(category);
                context.SaveChanges();

                return CreatedAtAction("GetCategoryByID", "Category", new { id = category.ID });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {

            //ID den bul
            Category category = context.Categories.SingleOrDefault(p => p.ID == id);

            var categoryProducts = context.Categories.OrderBy(e => e.Name).Include(e => e.Products).First();

            foreach (var post in categoryProducts.Products)
            {
                post.Category = null;
            }

            if (account == null)
            {
                return NotFound("Admin bulunamadı");
            }
            else if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            else
            {
                context.Categories.Remove(category);
                context.SaveChanges();

                return NoContent();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(Category category)
        {
            Category updated = context.Categories.SingleOrDefault(p => p.ID == category.ID);
            
            if (account == null)
            {
                return NotFound("Admin bulunamadı");
            }
            else if (category == null)
            {
                return NotFound("Kategori bulunamadı");
            }
            else
            {
                updated.Name = category.Name;
                context.SaveChanges();
                return CreatedAtAction("GetCategoryByID", "Category", new { id = category.ID });
            }
        }
    }
}
