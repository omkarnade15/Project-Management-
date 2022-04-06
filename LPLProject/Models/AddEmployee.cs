using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace LPLProject.Models
{
    public class AddEmployee
    {
        [Key]
        [Required(ErrorMessage = "*  Required")]
        [Display(Name = "Employee ID")]

        public string emp_ID { get; set; }
        [Required(ErrorMessage = "*  Required")]
        [Display(Name = "First Name")]
        public string first_Name { get; set; }
        [Required(ErrorMessage = "*  Required")]
        [Display(Name = "Last Name")]
        public string last_Name { get; set; }
    }
    
    
}