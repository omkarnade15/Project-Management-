using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace LPLProject.Models
{
    public class Task
    {
        [Key]
        public string task_ID { get; set; }
        [Required(ErrorMessage = "* Project name Required")]
        [Display(Name = "Project")]
        public string Project_tname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        
        [Display(Name = "Start Date")]
        public DateTime? start_date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
   
        [Display(Name = "End Date")]
        
       
        public DateTime? end_date { get; set; }
        public int priority { get; set; }

        [Display(Name = "Name of Task")]
        public string task_name { get; set; }
        [Display(Name = "Parent Task")]
        public string parent_task { get; set; }
        public string User { get; set; }
    }
}