﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShopWebApi.Models
{
    public class Users
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}