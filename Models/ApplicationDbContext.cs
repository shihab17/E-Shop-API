using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopWebApi.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base("DefualtConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}