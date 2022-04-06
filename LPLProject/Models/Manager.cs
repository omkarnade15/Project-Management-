using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPLProject.Models
{
    public class Manager
    {
        [Key]
        public string manager_name { get; set; }
        public string project_name { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "* Username Required")]
        public string username { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "* Password Required")]
        public string password { get; set; }

    }
}