using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trackingSystem.Models
{
    public class Account
    {
        public int ID { get; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}