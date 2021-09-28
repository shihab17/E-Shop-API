using OnlineShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShopWebApi.Controllers
{
    public class CartController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult AddCart([FromBody]Cart cart)
        {
            db.Cart.Add(cart);
            int row = db.SaveChanges();
            if (row > 0)
            {
                return Ok("Cart has been added");
            }
            else
            {
                return BadRequest("Failed to Saving Cart");
            }
        }
        [HttpGet]
        public IHttpActionResult GetAllCart()
        {
            var cart = db.Cart.ToList();
            if (cart.Count == 0)
            {
                return BadRequest("Category is empty");
            }
            else
            {
                return Ok(cart);
            }
        }
    }
}
