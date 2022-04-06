using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LPLProject.Models
{
    public class Project
    {
        [Key]
        [Required(ErrorMessage = "* Project name Required")]
        [Display(Name = "Project")]
        public string Project_name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required(ErrorMessage = "* Start date Required")]
        [Display(Name = "Start Date")]
        public DateTime Start_date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required(ErrorMessage = "* End date Required")]
        [Display(Name = "End Date")]

        public DateTime End_date { get; set; }
        public int Priority { get; set; }
        [Required(ErrorMessage = "* Manager Required")]
        public string Manager { get; set; }
        public int number_of_Tasks { get; set; }
        public string Status { get; set; }
        public string User { get;set; }

    }
}