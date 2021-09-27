using OnlineShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShopWebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult Add([FromBody] Categories categories)
        {
            db.Categories.Add(categories);
            int row = db.SaveChanges();
            if(row > 0)
            {
                return Ok("Categories has been added");
            }
            else
            {
                return BadRequest("Failed to Saving Categories");
            }
        }
        [HttpGet]
        public IHttpActionResult Categories()
        {
            var categories = db.Categories.ToList();
            if(categories.Count == 0)
            {
                return BadRequest("Category is empty");
            }
            else
            {
                return Ok(categories);
            }
        }
        [HttpGet]
        public IHttpActionResult CategoriesById(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] Categories categories)
        {
             if(categories.Id <= 0)
            {
                return NotFound();
            }
            else
            {
                db.Entry(categories).State = System.Data.Entity.EntityState.Modified;
                int row = db.SaveChanges();
                if (row > 0)
                {
                    return Ok(categories);
                }
                else
                {
                    return BadRequest("Can not update Category ");
                }
            }
            
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            else
            {
                db.Categories.Remove(category);
                int row = db.SaveChanges();
                if(row > 0)
                {
                    return Ok("Category has been Delected");
                }
                else
                {
                    return BadRequest("Failed to delete Category");
                }
            }
        }
    }
}
