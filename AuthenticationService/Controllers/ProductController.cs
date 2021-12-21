using AnindaKapinda.API.Services;
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
    public class ProductController : BaseController
    {
        public ProductController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {

        }

        [AllowAnonymous]
        public IActionResult GetProduct()
        {
            List<Product> products = context.Products.ToList();
            //List<Ph> courses = dbContext.Courses.Where(courses => courses.CourseID == lecturers.LecturerID).ToList();

            if (products.Count != 0)
            {
                foreach (var post in products)
                {
                    //if (products == null)
                    //{
                    //    //product.Photo = defaulth;
                    //}
                    post.Category = null;
                }

                return Ok(products);
            }

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            Product product = context.Products.SingleOrDefault(p => p.ProductId == id);

            if (product!=null)
            {
                if (product.Photo is null)
                {
                    //product.Photo = defaulth;
                }
                return Ok(product);
            }

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            Product exist = context.Products.SingleOrDefault(p => p.Name == product.Name);
            if(exist!=null)
            {
                return BadRequest("Ürün zaten kayıtlı");
            }
            if (account == null)
            {
                return NotFound("Admin bulunamadı");
            }
            else
            {
                context.Products.Add(product);
                context.SaveChanges();

                return Ok(product);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(int id)
        {
            //ID den bul
            Product product = context.Products.SingleOrDefault(p => p.ProductId == id);

            if (account == null)
            {
                return NotFound("Admin bulunamadı");
            }
            else if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            else
            {
                context.Products.Remove(product);
                context.SaveChanges();

                return NoContent();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Product product)
        {
            Product updated = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);

            if (account == null)
            {
                return NotFound("Admin bulunamadı");
            }
            else if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }
            else
            {
                updated.Name = product.Name;
                context.SaveChanges();
                return CreatedAtAction("GetProductByID", "Product", new { id = product.ProductId });
            }
        }
    }
}
