using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopWebApi.Models
{
    public class Cart
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string date { get; set; }   
        public int products_Id { get; set; } 
    }
}