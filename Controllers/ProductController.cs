using OnlineShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShopWebApi.Controllers
{
    public class ProductController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]  
        public IHttpActionResult Add([FromBody] Product product)
        {
            db.Products.Add(product);
            int row = db.SaveChanges();
            if(row > 0)
            {
                return Ok("Product has been added");
            }
            else
            {
                return BadRequest("Failed to Saving product");
            }
        }
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var products = db.Products.ToList();
            if(products.Count == 0)
            {
                return NotFound();
            }
            else
            {
               return Ok(products);
            }
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var product = db.Products.FirstOrDefault(pd => pd.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
        [HttpPut]
        public IHttpActionResult Update([FromBody] Product product)
        {
            if(product.Id <= 0)
            {
                return NotFound();
            }
            else
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                int row = db.SaveChanges();
                if(row > 0)
                {
                    return Ok(product);
                }
                else
                {
                    return BadRequest("Can not update this " + product.Id);
                }
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(pd => pd.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                db.Products.Remove(product);
                int row = db.SaveChanges();
                if(row > 0)
                {
                    return Ok("Product has been Delected");
                }
                else
                {
                    return BadRequest("Failed to delete product");
                }
            }
        }

    }
}
