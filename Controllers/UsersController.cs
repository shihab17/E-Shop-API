using OnlineShopWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineShopWebApi.Controllers
{
    public class UsersController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] Users user)
        {
            db.Users.Add(user);
            int row = db.SaveChanges();
            if(row > 0)
            {
               return Ok("Successfully added a new user ");
            }
            else
            {
                return BadRequest("Failed to Saving User");
            }
        }
        [HttpGet]
        public IHttpActionResult Users()
        {
            var users = db.Users.ToList();
            if(users.Count == 0)
            {
                return BadRequest("There are no User found");
            }
            else
            {
                return Ok(users);
            }
        }
        [HttpGet]
        public IHttpActionResult UserById(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.id == id);
            if(user == null)
            {
                return BadRequest("Can not found this user");
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpPut]
        public IHttpActionResult UserUpdate([FromBody] Users user)
        {
            if(user.id <= 0)
            {
                return BadRequest("Invalid User");
            }
            else
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                int row = db.SaveChanges();
                if(row > 0)
                {
                    return Ok("Successfully Updated");
                }
                else
                {
                    return BadRequest("Unsuccessful Update User");
                }
            }
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.id == id);
            if(user == null)
            {
                return NotFound();
            }
            else
            {
                db.Users.Remove(user);
                int row = db.SaveChanges();
                if (row > 0)
                {
                    return Ok("User has been Delected");
                }
                else
                {
                    return BadRequest("Failed to delete User");
                }
            }
        }
        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.username == username && u.password == password);
            if (user == null)
            {
                return BadRequest("Invaild username or password");
            }
            else
            {
                return Ok("Vaild User");
            }
        }
    }
}
