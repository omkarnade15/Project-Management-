using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPLProject.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        public string user_name { get; set; }

    }
}