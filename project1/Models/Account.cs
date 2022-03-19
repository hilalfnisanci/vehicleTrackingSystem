using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace trackingSystem.Models
{
    public class Account
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Mail { get; set; }
        public List<String> CarIDs { get; set; }
    }
}